namespace Pantry.Graph;

internal class InstructionComparer : IEqualityComparer<Instruction>
{
    private readonly IEqualityComparer<string> _stringComparer;

    public InstructionComparer()
    {
        _stringComparer = StringComparer.OrdinalIgnoreCase;
    }

    public bool Equals(Instruction? x, Instruction? y)
    {
        if (x == null && y == null)
        {
            return true;
        }

        if (x == null || y == null)
        {
            return false;
        }

        return _stringComparer.Equals(x.Name, y.Name);
    }

    public int GetHashCode(Instruction obj) => HashCode.Combine(obj.Name);
}