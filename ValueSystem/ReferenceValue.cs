using SER.Helpers.Exceptions;
using SER.Helpers.Extensions;

namespace SER.ValueSystem;

public class ReferenceValue(object? value) : Value
{
    public bool IsValid => value is not null;
    public object Value => value ?? throw new ScriptRuntimeError("Value of reference is invalid.");

    public override bool EqualCondition(Value other)
    {
        if (other is not ReferenceValue otherP || !IsValid || !otherP.IsValid) return false;
        return Value.Equals(otherP.Value);
    }

    public override string ToString()
    {
        return $"<{Value.GetType().GetAccurateName()} reference | {Value.GetHashCode()}>";
    }
}

public class ReferenceValue<T>(T? value) : ReferenceValue(value)
{
    public new T Value => (T) base.Value;
}