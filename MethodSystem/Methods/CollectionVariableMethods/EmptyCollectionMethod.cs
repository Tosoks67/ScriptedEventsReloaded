using SER.ArgumentSystem.BaseArguments;
using SER.MethodSystem.BaseMethods;
using SER.ValueSystem;

namespace SER.MethodSystem.Methods.CollectionVariableMethods;
public class EmptyCollectionMethod : ReturningMethod<CollectionValue>
{
    public override string Description => "Returns an empty collection.";

    public override Argument[] ExpectedArguments { get; } = [];

    public override void Execute()
    {
        ReturnValue = new CollectionValue(Array.Empty<Value>());
    }
}