namespace Pantry.Graph;

internal class InstructionGraph
{
    public static InstructionGraph FromDescriptors(IEnumerable<InstructionDescriptor> descriptors)
    {
        var graph = new InstructionGraph();
        foreach (var descriptor in descriptors)
        {
            foreach (var before in descriptor.RunBefore)
            {
                graph.Connect(GraphNode.FromDescriptor(descriptor), new GraphNode(before));
            }
            
            foreach (var after in descriptor.RunAfter)
            {
                graph.Connect(new GraphNode(after), GraphNode.FromDescriptor(descriptor));
            }
        }

        return graph;
    }

    private readonly IEqualityComparer<GraphNode> _comparer;

    private InstructionGraph()
    {
        _comparer = new GraphNodeComparer();
        Nodes = new HashSet<GraphNode>();
        Edges = new HashSet<GraphEdge>();
    }

    public HashSet<GraphNode> Nodes { get; }
    public HashSet<GraphEdge> Edges { get; }

    internal void Connect(GraphNode from, GraphNode to)
    {
        if (from == null)
        {
            throw new ArgumentNullException(nameof(from));
        }

        if (to == null)
        {
            throw new ArgumentNullException(nameof(to));
        }

        if (_comparer.Equals(from, to))
        {
            throw new InvalidOperationException("Reflexive dependencies are not allowed.");
        }

        if (Edges.Any(e => _comparer.Equals(e.From, to) && _comparer.Equals(e.To, from)))
        {
            throw new InvalidOperationException("Unidirectional dependencies are not allowed.");
        }

        if (!Nodes.Contains(from))
        {
            Nodes.Add(from);
        }

        if (!Nodes.Contains(to))
        {
            Nodes.Add(to);
        }

        if (!Edges.Any(e => _comparer.Equals(e.From, from) && _comparer.Equals(e.To, to)))
        {
            Edges.Add(new GraphEdge(from, to));
        }
    }
}