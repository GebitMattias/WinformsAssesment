using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
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
    public IEnumerable<Person> GetPersons()
    {
        var random = new Random();

        // Simulate it sometimes failing
        if (random.Next(10_000) <= 5) throw new IOException();

        // Simulate some work
        Thread.Sleep(random.Next(5000, 10000));

        return this._generator.GeneratePersons();
    }

    /// <summary>
    /// Get Addresses
    /// </summary>
    /// <exception cref="IOException">IO might fail rarely</exception>
    public IEnumerable<Address> GetAddresses()
    {
        var random = new Random();

        // Simulate it sometimes failing
        if (random.Next(10_000) <= 5) throw new IOException();

        // Simulate some work
        Thread.Sleep(random.Next(5000, 10000));

        return this._generator.GenerateAddresses();
    }

}