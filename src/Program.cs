public class Program
{
    public static void Main(string[] args)
    {
    }


    public static void DefaultGraph()
    {
        Graph<int> graph = new Graph<int>();
        Graph<int>.Node A = graph.CreateNode("A");
        Graph<int>.Node B = graph.CreateNode("B");
        Graph<int>.Node C = graph.CreateNode("C");
        Graph<int>.Node D = graph.CreateNode("D");
        Graph<int>.Node E = graph.CreateNode("E");
        graph.Connect(A, B, C);
        graph.Connect(B, D);
        graph.DeleteNode(B);
        graph.PrintGraph();
    }
    public static void FancyGraph()
    {
        Graph<int> graph = new Graph<int>();
        Graph<int>.Node[]? nodes = graph.CreateNodeMulti(5);
        if (nodes == null) return;
        graph.Connect(nodes[0], nodes[1], nodes[2]);
        graph.Connect(nodes[1], nodes[3]);
        graph.DeleteNode(nodes[1]);
        graph.PrintGraph();

    }
}
