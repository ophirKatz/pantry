namespace Pantry.Core.Instructions;

public abstract class Instruction
{
    protected Instruction(string name)
    {
        Name = name;
    }

    internal string Name { get; set; }
    internal string? Description { get; set; }

    public void Describe(string description) => Description = description;
}