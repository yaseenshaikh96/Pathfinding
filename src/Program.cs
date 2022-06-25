public enum SearchType { BFS, DFS }

public class Program
{
    private static SearchType searchType = SearchType.DFS;
    private static bool printEnqueueCount = true;

    public static void Main(string[] args)
    {
        Graph<int>? graph = ExampleGraph.ExampleGraph5();
        if (graph == null)
        {
            System.Console.Write("Graph is null");
            return;
        }
        graph.PrintGraph();
        System.Console.WriteLine("SearchType: " + searchType.ToString());
        var path = SearchGraph(graph, graph.GetNodes()[4]);
        if (path == null)
        {
            System.Console.Write("Path is null");
            return;
        }
        Graph<int>.PrintPath(path);
    }

    private static List<Graph<T>.Node>? SearchGraph<T>(
        Graph<T> graph,
        Graph<T>.Node endingNode,
        Graph<T>.Node? startingNode = null)
    {
        if (startingNode == null)
            startingNode = graph.GetNodes()[0];

        List<Graph<T>.Node>? path;
        switch (searchType)
        {
            case SearchType.BFS:
                path = Search.BFS(graph, endingNode, printEnqueueCount, startingNode);
                break;
            case SearchType.DFS:
                path = Search.DFS(graph, endingNode, printEnqueueCount, startingNode);
                break;
            default:
                path = null;
                break;
        }
        return path;
    }
}
