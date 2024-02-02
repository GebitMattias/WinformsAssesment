using IOLib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IOLib
{
    public partial class frmMain : Form
    {
        //Cancellation Token for the option to cancel the IO Worker
        private CancellationTokenSource ioWorkerCancellationTokenSource = new CancellationTokenSource();
        //Failsave to be sure that not annother IOWorker is started
        private bool isWorkerRunning = false;

        public frmMain()
        {
            InitializeComponent();
        }

        #region UI Buttons
        /// <summary>
        /// UI Button to select the Folder of the data retrieval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                tbFolder.Text = folderDialog.SelectedPath;
            }
        }

        /// <summary>
        /// UI Button to start the data retrieval process and show it in the Result TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnStartIOWorker_Click(object sender, EventArgs e)
        {
            //Be sure, that the Worker is only started once
            if (isWorkerRunning) { return; }

            //Close UI to show that a Worker is running
            CloseUIForIOWorker();

            //Clear the potential old results for a correct result
            ClearTextBoxes();

            AddStatus("Process Started");

            //Cancel if selected folder is empty
            if (tbFolder.Text == "")
            {
                AddStatus("Process Stopped - No Folder selected");
                OpenUIForIOWorker();
                return;
            }

            //Dictionaries for easier Data Handling and potential further actions
            Dictionary<Guid, Address> addresses = new Dictionary<Guid, Address>();
            Dictionary<int, Person> persons = new Dictionary<int, Person>();

            AddStatus("Create IO Worker");
            IOWorker ioWorker = new IOWorker(tbFolder.Text);

            //Try to collect the Address Data
            #region Collect Addresses
            try
            {
                //Collect the Address Information
                AddStatus("Collect Addresses");
                IEnumerable<Address> addressResult = await ioWorker.GetAddresses(ioWorkerCancellationTokenSource);

                //Convert into a Dictionary for easier combination of Person and Address
                foreach (Address address in addressResult)
                {
                    addresses.Add(address.Id, address);
                }
            }
            catch (OperationCanceledException ex)
            {
                //Prompt Error to Status
                AddStatus("Process Cancelled by User");

                //Prompt to Console for DEBUG Resons                
                Debug.Write(ex.ToString());

                //Reset Cancellation Token
                ioWorkerCancellationTokenSource.Dispose();
                ioWorkerCancellationTokenSource = new CancellationTokenSource();

                //Opens UI for annother request
                OpenUIForIOWorker();
                return;
            }
            catch (Exception ex)
            {
                //Prompt Error to Status
                AddStatus("Process Stopped - Error on collecting Addresses");
                AddStatus($"{ex.Message}");

                //Prompt to Console for DEBUG Resons                
                Debug.Write(ex.ToString());

                //Opens UI for annother request
                OpenUIForIOWorker();
                return;
            }
            #endregion Collect Addresses

            //Try to collect the Person Data,
            #region Collect Persons
            try
            {
                //Collect the Person Information
                AddStatus("Collect Persons");
                IEnumerable<Person> personResult = await ioWorker.GetPersons(ioWorkerCancellationTokenSource);

                //Convert data into a dictionary for easier combination of Address and Person
                foreach (Person person in personResult)
                {
                    persons.Add(person.Id, person);                    
                }
            }
            catch (OperationCanceledException ex)
            {
                //Prompt Error to Status
                AddStatus("Process Cancelled by User");

                //Prompt to Console for DEBUG Resons                
                Debug.Write(ex.ToString());

                //Reset Cancellation Token
                ioWorkerCancellationTokenSource.Dispose();
                ioWorkerCancellationTokenSource = new CancellationTokenSource();

                //Opens UI for annother request
                OpenUIForIOWorker();
                return;
            }
            catch (Exception ex)
            {
                //Prompt Error to Status
                AddStatus("Process Stopped - Error on collecting Persons");
                AddStatus($"{ex.Message}");

                //Prompt to Console for DEBUG Resons                
                Debug.Write(ex.ToString());

                //Opens UI for annother request
                OpenUIForIOWorker();
                return;
            }
            #endregion Collect Persons

            #region Show Result in the UI
            //Prompt the results of Collecting Data to the result text box
            AddStatus("Prompt Result in UI");
            foreach (KeyValuePair<int,Person> person in persons)
            {
                AddPersonToTextbox(person.Value, addresses.ContainsKey(person.Value.Address_Id) ? addresses[person.Value.Address_Id] : null);
            }            
            #endregion Show Result in the UI

            //Opens UI for annother request
            OpenUIForIOWorker();
            AddStatus("Process Successfull ended");
        }

        /// <summary>
        /// Button to Cancel the current IO Worker Process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelIOWorker_Click(object sender, EventArgs e)
        {
            AddStatus("Cancellation requested");
            ioWorkerCancellationTokenSource.Cancel();

        }
        #endregion UI Buttons


        /// <summary>
        /// Clears the Result and Status TextBox
        /// </summary>
        private void ClearTextBoxes()
        {
            tbResult.Text = "";
            tbStatus.Text = "";
        }

        /// <summary>
        /// Adds the Result of the IOWorker to the TextBoxes      
        /// </summary>
        /// <param name="person">The Person to Show</param>
        /// <param name="address">The Address of the Persion, Standard Value = Null </param>
        private void AddPersonToTextbox(Person person, Address address = null)
        {
            //Used for a thread safe change of the UI
            this.Invoke(new MethodInvoker(delegate
            {
                //Append the person to the result text box
                tbResult.AppendText($"{person.Name}\r\n");

                //Add to the results text box the Address of the Person or an "N/A" if no address was found
                if (address == null)
                {
                    tbResult.AppendText($"\tN/A\r\n");
                }
                else
                {
                    tbResult.AppendText($"\t{address.Street}\r\n");
                    tbResult.AppendText($"\t{address.City}\r\n");
                }
            }));
        }

        /// <summary>
        /// Adds a Status Text to the Status UI
        /// </summary>
        /// <param name="statusText"></param>
        private void AddStatus(String statusText)
        {
            //Used for a thread safe change of the UI
            this.Invoke(new MethodInvoker(delegate
            {
                tbStatus.AppendText($"{statusText}\r\n");
            }));
        }

        /// <summary>
        /// Closes the UI for additional IO Worker Calls and opens the possibility to cancel the process
        /// </summary>
        private void CloseUIForIOWorker()
        {
            isWorkerRunning = true;

            btnSelectFolder.Enabled = false;
            btnStartIOWorker.Enabled = false;

            btnCancelIOWorker.Enabled = true;
        }

        /// <summary>
        /// Opens the UI for the next IO Worker Calls and disables Cancel Button
        /// </summary>
        private void OpenUIForIOWorker()
        {
            btnCancelIOWorker.Enabled = false;

            btnSelectFolder.Enabled = true;
            btnStartIOWorker.Enabled = true;

            isWorkerRunning = false;
        }

    }
}
