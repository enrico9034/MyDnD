global using NUnit.Framework;
global using DnD.Core;
global using DnD.Core.LuaObjects;
global using FluentAssertions;
using DnD.Core.ScriptSuppliers;
using FileSystemConfigurationSupplier;
using FluentAssertions.Primitives;

public static class UtilBuilder
{
    public static IScriptSupplier GetLuaSupplier()
    {
        return new ScriptSupplier();
    }
}