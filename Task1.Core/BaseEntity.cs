namespace Task1.Core;

public class BaseEntity
{
    public string PublicMember = "Public";
    private string PrivateMember = "Private";
    protected string ProtectedMember = "Protected";
    internal string InternalMember = "Internal";
    protected internal string ProtectedInternalMember = "Protected Internal";
    private protected string PrivateProtectedMember = "Private Protected";

    public void TestFromBase()
    {
        Console.WriteLine($"{PublicMember}, {PrivateMember}, {ProtectedMember}, {InternalMember}, {ProtectedInternalMember}, {PrivateProtectedMember}");
    }
}

public class SameAssemblyDerived : BaseEntity
{
    public void TestFromSameAssemblyDerived()
    {
        _ = PublicMember;            // OK
        // _ = PrivateMember;        // CS0122
        _ = ProtectedMember;         // OK
        _ = InternalMember;          // OK
        _ = ProtectedInternalMember; // OK
        _ = PrivateProtectedMember;  // OK
    }
}

public static class SameAssemblyClient
{
    public static void TestAccess()
    {
        var obj = new BaseEntity();
        _ = obj.PublicMember;            // OK
        // _ = obj.PrivateMember;        // CS0122
        // _ = obj.ProtectedMember;      // CS0122
        _ = obj.InternalMember;          // OK
        _ = obj.ProtectedInternalMember; // OK
        // _ = obj.PrivateProtectedMember; // CS0122
    }
}