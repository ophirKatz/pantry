namespace Pantry.Graph;

internal class GraphNodeComparer : IEqualityComparer<GraphNode>
{
    private readonly IEqualityComparer<string> _stringComparer;

    public GraphNodeComparer()
    {
        _stringComparer = StringComparer.OrdinalIgnoreCase;
    }

    public bool Equals(GraphNode? x, GraphNode? y)
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

    public int GetHashCode(GraphNode obj) => HashCode.Combine(obj.Name);
}