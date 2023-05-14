namespace Pantry.Graph;

internal class InstructionGraphWalker
{
    private readonly IEqualityComparer<GraphNode> _comparer;

    public InstructionGraphWalker()
    {
        _comparer = new GraphNodeComparer();
    }

    private class TargetInstruction : Instruction
    {
        public static readonly GraphNode Node = new(new TargetInstruction());

        private TargetInstruction() : base("__target__")
        {
        }
    }

    public IEnumerable<Instruction> Walk(InstructionGraph graph)
    {
        // Clone the graph.
        //graph = graph.ShallowClone();

        // Find all nodes without any edges.
        var orphans = graph.Nodes
            .Where(x => !graph.Edges.Any(edge => _comparer.Equals(x, edge.From))
                && !graph.Edges.Any(edge => _comparer.Equals(x, edge.To)))
            .ToArray();

        // Find all leaves in the graph.
        var leaves = graph.Nodes
            .Where(x => graph.Edges.Any(y => _comparer.Equals(x, y.To))
                && !graph.Edges.Any(z => _comparer.Equals(x, z.From)))
            .ToArray();

        // Add an artificial destination node to all leaves.
        // This will be the target to traverse to it's roots.
        var target = TargetInstruction.Node;
        foreach (var leaf in leaves.Concat(orphans))
        {
            graph.Connect(leaf, target);
        }

        // Traverse the graph.
        var result = new List<GraphNode>();
        Traverse(graph, target, result);

        // Remove the target node from the results.
        result.RemoveAll(x => x.Name == "__target__");

        // Return the result.
        return result.Select(x => x.Instruction);
    }

    private void Traverse(
        InstructionGraph graph,
        GraphNode node,
        ICollection<GraphNode> result,
        ISet<GraphNode>? visited = null)
    {
        visited ??= new HashSet<GraphNode>(_comparer);
        if (!visited.Contains(node))
        {
            visited.Add(node);
            var incoming = graph.Edges.Where(x => _comparer.Equals(x.To, node)).Select(x => x.From);
            foreach (var child in incoming)
            {
                Traverse(graph, child, result, visited);
            }

            result.Add(node);
        }
        else if (!result.Any(x => _comparer.Equals(x, node)))
        {
            throw new InvalidOperationException("Graph contains circular references.");
        }
    }

    private static void EnsureInstructionExist(InstructionGraph graph, Instruction identity)
    {
        if (!graph.Nodes.Any(r => r.Name.Equals(identity.Name, StringComparison.OrdinalIgnoreCase)
            && r.ResourceType == identity.ResourceType))
        {
            throw new InvalidOperationException(
                $"Could not find resource '{identity.Name}' of type '{identity.ResourceType.Name}'.");
        }
    }
}