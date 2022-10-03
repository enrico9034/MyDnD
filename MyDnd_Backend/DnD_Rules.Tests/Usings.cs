global using NUnit.Framework;
global using DnD;
global using DnD.LuaObjects;
global using FluentAssertions;
using FluentAssertions.Primitives;

public static class NunitExtensions
{
    public static ObjectAssertions Should<TType>(this object? target)
    {
        return ((TType)target).Should();
    }
}