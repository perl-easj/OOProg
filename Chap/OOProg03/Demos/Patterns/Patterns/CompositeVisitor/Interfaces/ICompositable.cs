namespace Patterns.CompositeVisitor.Interfaces
{
    public interface ICompositable
    {
        double Price { get; }
        double Weight { get; }
        string WhatAmI { get; }
    }
}