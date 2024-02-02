using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using IOLib.Model;

namespace IOLib;

/// <summary>Class doing some IO work</summary>
public sealed class IOWorker
{
    private readonly DataGenerator _generator = new();

    public IOWorker(string path)
    {

    }

    /// <summary>
    /// Get Persons
    /// </summary>
    /// <exception cref="IOException">IO might fail rarely</exception>
    /// Exceptions are not handled within this task, because they will handeld by the calling Method
    public Task<IEnumerable<Person>> GetPersons(CancellationTokenSource cts)
    {
        CancellationToken ct = cts.Token;


        return Task.Run(() =>
        {
            //Check if already cancelled
            ct.ThrowIfCancellationRequested();

            var random = new Random();

            // Simulate it sometimes failing
            if (random.Next(10_000) <= 5) throw new IOException();

            // Simulate some work
            Thread.Sleep(random.Next(5000, 10000));

            //Check if User cancelled Now, should be within the work
            if (ct.IsCancellationRequested) { ct.ThrowIfCancellationRequested(); }

            return this._generator.GeneratePersons();
        }, ct);

    }

    /// <summary>
    /// Get Addresses
    /// </summary>
    /// <exception cref="IOException">IO might fail rarely</exception>
    /// Exceptions are not handled within this task, because they will handeld by the calling Method
    public Task<IEnumerable<Address>> GetAddresses(CancellationTokenSource cts)
    {
        CancellationToken ct = cts.Token;

        return Task.Run(() =>
        {
            //Check if already cancelled
            ct.ThrowIfCancellationRequested();

            var random = new Random();

            // Simulate it sometimes failing
            if (random.Next(10_000) <= 5) throw new IOException();

            // Simulate some work
            Thread.Sleep(random.Next(5000, 10000));

            //Check if User cancelled Now, should be within the work
            if (ct.IsCancellationRequested) { ct.ThrowIfCancellationRequested(); }


            return this._generator.GenerateAddresses();
        }, ct);
    }

}