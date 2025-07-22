using System;
using System.Reflection;

namespace DomainLedger.Budgeting.ArchTests;

public abstract class TestBase
{
    protected readonly Assembly InfrastructureAssembly = DomusLedger.Budgeting.Infrastructure.AssemblyReference.Assembly;
    protected readonly Assembly CoreAssembly = DomusLedger.Budgeting.Core.AssemblyReference.Assembly;

}
