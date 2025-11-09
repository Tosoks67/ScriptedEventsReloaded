using SER.Helpers.ResultSystem;
using SER.ScriptSystem;
using SER.ValueSystem;

namespace SER.TokenSystem.Tokens;

public class NumberToken : LiteralValueToken<NumberValue>
{
    protected override IParseResult InternalParse(Script scr)
    {
        if (TryParse(RawRep).WasSuccessful(out var value))
        {
            Value = value;
            return new Success();
        }

        return new Ignore();
    }

    public static TryGet<decimal> TryParse(string stringRep)
    {
        if (decimal.TryParse(stringRep, out var value))
        {
            return value;
        }

        if (stringRep.EndsWith("%") && decimal.TryParse(stringRep.TrimEnd('%'), out value))
        {
            return value / 100;
        }

        return $"Value '{stringRep}' is not a valid number";
    }
}