using System;
using System.Collections.Generic;
using IOLib.Model;

namespace IOLib;

/// <summary>Generates some Data</summary>
internal sealed class DataGenerator
{
    private readonly Address[] _addresses;

    private readonly Person[] _persons;

    public DataGenerator()
    {
        this._addresses = new Address[] {
            new(){Id = Guid.NewGuid(), Street = "Fake Street 123", City = "Springfield"},
            new(){Id = Guid.NewGuid(), Street = "Evergreen Terrace 744", City = "Springfield"},
            new(){Id = Guid.NewGuid(), Street = "Evergreen Terrace 743", City = "Springfield"},
        };
        this._persons = new Person[] {
            new(){Id = 1, Name = "Fake Name", Address_Id = this._addresses[0].Id},
            new(){Id = 2, Name = "Simpson", Address_Id = this._addresses[1].Id },
            new(){Id = 3, Name = "Bush", Address_Id = this._addresses[2].Id},
            new(){Id = 4, Name = "Muster4"},
            new(){Id = 5, Name = "Muster5"},
        };
    }


    public IEnumerable<Person> GeneratePersons()
    {
        return this._persons;
    }

    public IEnumerable<Address> GenerateAddresses()
    {
        return this._addresses;
    }
}