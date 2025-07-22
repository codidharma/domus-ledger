using System;
using System.Reflection;

namespace DomusLedger.Budgeting.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;

}
