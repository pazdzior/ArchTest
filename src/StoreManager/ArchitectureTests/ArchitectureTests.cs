using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.Fluent;
using ArchUnitNET.Fluent.Slices;
using ArchUnitNET.NUnit;
using StoreManager.Repository;
using StoreManager.Services;
using StoreManager.Services.Models;
using StoreManager.WebApp.Controllers;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ArchitectureTests;

public class ArchitectureTests
{
    private static readonly Architecture Architecture =
        new ArchLoader().LoadAssemblies(typeof(StoreManagerRepository).Assembly,
            typeof(ArticleService).Assembly,
            typeof(ArticleController).Assembly).Build();

    // Components defined based on assembly
    private static readonly IObjectProvider<IType> RepositoryComponent =
        Types()
            .That()
            .ResideInAssembly("StoreManager.Repository", true)
            .As("Repository Component");

    private static readonly IObjectProvider<IType> WebAppComponent =
        Types()
            .That()
            .ResideInAssembly("StoreManager.WebApp", true)
            .As("Web Application Component");

    private static readonly IObjectProvider<IType> ServiceComponent =
        Types()
            .That()
            .ResideInAssembly("StoreManager.Services", true)
            .As("Service Component");


    // Components defined based on namespace
    private static readonly IObjectProvider<IType> RepositoryComponentByNamespace =
        Types()
            .That()
            .ResideInNamespace("StoreManager.Repository", true)
            .As("Repository Component");

    private static readonly IObjectProvider<IType> ServiceComponentByNamespace =
        Types()
            .That()
            .ResideInNamespace("StoreManager.Services", true)
            .As("Service Component");

    private static readonly IObjectProvider<IType> WebAppComponentByNamespace =
        Types()
            .That()
            .ResideInNamespace("StoreManager.WebApp", true)
            .As("Web Application Component");


    [SetUp]
    public void Setup()
    {
    }

    // Assembly based components dependency rule
    [Test]
    public void WebApp_Component_MustNot_Depend_On_Repository_Component()
    {
        IArchRule rule =
            Types()
                .That()
                .Are(WebAppComponent)
                .Should()
                .NotDependOnAny(RepositoryComponent)
                .Because("Web Application component must not depend on Repository component.");

        rule.Check(Architecture);
    }


    // Namespace based components dependency rule
    [Test]
    public void WebApp_Component_MustNot_Depend_On_Repository_Component_Based_On_Namespace()
    {
        IArchRule rule =
            Types()
                .That()
                .Are(WebAppComponentByNamespace)
                .Should()
                .NotDependOnAny(RepositoryComponentByNamespace)
                .Because("Web Application component must not depend on Repository component.");
        rule.Check(Architecture);
    }


    // Class dependency rule 
    [Test]
    public void Classes_That_Inherit_IServiceModel_Should_Not_Depend_On_IService()
    {
        IArchRule rule =
            Classes()
                .That()
                .AreAssignableTo(typeof(IServiceModel))
                .Should()
                .NotDependOnAny(Classes().That().AreAssignableTo(typeof(IService)))
                .Because("it is forbidden!");

        rule.Check(Architecture);
    }

    // Naming check rule based on namespace
    [Test]
    public void Services_Must_Have_Correct_Name()
    {
        IArchRule rule = Classes()
            .That()
            .ResideInNamespace("StoreManager.Services")
            .Should()
            .HaveNameEndingWith("Service")
            .Because("all Service classes must have name ending with \"Service\"");
        rule.Check(Architecture);
    }

    // Naming check rule based interface implementation
    [Test]
    public void Classes_That_Implement_IService_Should_Have_Correct_Name()
    {
        IArchRule rule = Classes()
            .That()
            .AreAssignableTo(typeof(IService))
            .Should()
            .HaveNameEndingWith("Service")
            .Because("all classes that inherit IService must have name ending with \"Service\"");

        rule.Check(Architecture);
    }

    // Class Namespace Containment Rule    
    [Test]
    public void Service_Classes_Must_Reside_In_Services_Namespace()
    {
        IArchRule rule = Classes()
            .That()
            .HaveNameEndingWith("Service")
            .Should()
            .ResideInNamespace("StoreManager.Services")
            .Because("all services must reside in the StoreManager.Service namespace.");

        rule.Check(Architecture);
    }


    // Class Assembly Containment Rule
    [Test]
    public void Service_Classes_Must_Reside_In_Services_Assembly()
    {
        IArchRule rule = Classes()
            .That()
            .HaveNameEndingWith("Service")
            .Should()
            .ResideInAssembly("StoreManager.Services", true)
            .Because("all service must reside in the StoreManager.Services assembly.");
        rule.Check(Architecture);
    }


    // Assembly Namespace Consistency Rule    
    [Test]
    public void Types_That_ResideIn_Services_Assembly_Should_Have_Correct_Namespace()
    {
        IArchRule rule = Types()
            .That()
            .ResideInAssembly("StoreManager.Services", true)
            .Should()
            .ResideInNamespace("StoreManager.Services", true);
        rule.Check(Architecture);
    }


    // Cyclic dependency Rule
    [Test]
    public void Cyclic_Dependency_Check()
    {
        var sliceRule = SliceRuleDefinition.Slices()
            .Matching("StoreManager.(**)")
            .Should()
            .BeFreeOfCycles();
        sliceRule.Check(Architecture);
    }
}