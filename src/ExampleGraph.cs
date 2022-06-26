public static class ExampleGraph
{
    public static Graph<int> ExampleGraph6()
    {
        GraphData graphData = new GraphData(8,
        0, 0, 0, 0, 0, 0, 0, 0, // 1
        1, 0, 0, 0, 0, 0, 0, 0, // 2
        9, 0, 0, 0, 0, 0, 0, 0, // 3
        0, 5, 0, 0, 0, 0, 0, 0, // 4
        0, 5, 0, 0, 0, 0, 0, 0, // 5
        0, 0, 0, 5, 0, 0, 0, 0, // 6
        0, 0, 0, 5, 0, 0, 0, 0, // 7
        0, 0, 1, 0, 0, 0, 5, 0);// 8
        return new Graph<int>(graphData);
    }
    public static Graph<int> ExampleGraph5()
    {
        GraphData graphData = new GraphData(5,
        0, 0, 0, 0, 0,
        1, 0, 0, 0, 0,
        0, 1, 0, 0, 0,
        0, 4, 1, 0, 0,
        0, 4, 0, 1, 0);
        return new Graph<int>(graphData);
    }
    public static Graph<int> ExampleGraph4()
    {
        Graph<int> graph = new Graph<int>();
        Graph<int>.Node S = graph.CreateNode("S");
        Graph<int>.Node A = graph.CreateNode("A");
        Graph<int>.Node B = graph.CreateNode("B");
        Graph<int>.Node C = graph.CreateNode("C");
        Graph<int>.Node D = graph.CreateNode("D");
        Graph<int>.Node E = graph.CreateNode("E");
        Graph<int>.Node G = graph.CreateNode("G");
        graph.Connect(S, A, 3);
        graph.Connect(S, B, 5);
        graph.Connect(A, B, 4); // 2->4
        graph.Connect(A, D, 3);
        graph.Connect(B, C, 4);
        graph.Connect(D, G, 5);
        graph.Connect(C, E, 6);
        return graph;
    }
    public static Graph<int[]>? ExampleGraph3()
    {
        Graph<int[]> graph = new Graph<int[]>();
        Graph<int[]>.Node[]? nodes = graph.CreateNodeMulti(5);
        if (nodes == null) return null;
        graph.Connect(nodes[0], nodes[1], nodes[2]);
        graph.Connect(nodes[1], nodes[3]);
        return graph;
    }
    public static Graph<int>? ExampleGraph2()
    {
        Graph<int> graph = new Graph<int>();
        Graph<int>.Node[]? nodes = graph.CreateNodeMulti(5);
        if (nodes == null) return null;
        graph.Connect(nodes[0], nodes[1], nodes[2]);
        graph.Connect(nodes[1], nodes[3]);
        graph.DeleteNode(nodes[1]);
        return graph;
    }
    public static Graph<int> ExampleGraph1()
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
        return graph;
    }

}