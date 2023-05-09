namespace Pantry;

public abstract class Target
{
    protected Target(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public string? Description { get; set; }
}