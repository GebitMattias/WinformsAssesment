using System;

namespace IOLib.Model;

public sealed class Address
{
    public Guid Id { get; init; }

    public string Street { get; init; }

    public string City { get; init; }
}