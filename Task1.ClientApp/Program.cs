using Task1.Core;

namespace Task1.ClientApp;

public class ExternalAssemblyDerived : BaseEntity
{
    public void TestFromExternalDerived()
    {
        _ = PublicMember;            // OK
        // _ = PrivateMember;        // CS0122
        _ = ProtectedMember;         // OK
                                     // _ = InternalMember;          // ПОМИЛКА CS0122 (інша збірка)
        _ = ProtectedInternalMember; // OK
                                     //  _ = PrivateProtectedMember;  // ПОМИЛКА CS0122 (інша збірка)
    }
}

class Program
{
    static void Main()
    {
        var obj = new BaseEntity();
        Console.WriteLine($"Доступно з зовнішньої збірки: {obj.PublicMember}");

        var derived = new ExternalAssemblyDerived();
        derived.TestFromExternalDerived();
    }
}