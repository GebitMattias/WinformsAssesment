using System;

namespace IOLib.Model;

public sealed class Person
{
    public int Id { get; init; }

    public string Name { get; init; }

    public Guid Address_Id { get; init; }
}