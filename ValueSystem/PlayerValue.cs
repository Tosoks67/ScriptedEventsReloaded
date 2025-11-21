using LabApi.Features.Wrappers;

namespace SER.ValueSystem;

public class PlayerValue : Value
{
    public PlayerValue(Player plr)
    {
        Players = [plr];
    }

    public PlayerValue(IEnumerable<Player> players)
    {
        Players = players.ToArray();
    }

    public Player[] Players { get; }

    public override bool EqualCondition(Value other) => other is PlayerValue otherP && Players.SequenceEqual(otherP.Players);
    
    public override int HashCode => Players.GetHashCode();
}