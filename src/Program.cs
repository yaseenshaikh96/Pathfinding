public enum SearchType { BFS, DFS, GREEDY }

public class Program
{
    private static SearchType searchType = SearchType.GREEDY;
    private static bool printEnqueueCount = true;

    public static void Main(string[] args)
    {
        Graph<int>? graph = ExampleGraph.ExampleGraph4();
        if (graph == null)
        {
            System.Console.Write("Graph is null");
            return;
        }
        graph.PrintGraph();
        System.Console.WriteLine("SearchType: " + searchType.ToString());
        var path = SearchGraph(graph, graph.GetNodes()[6]);
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
            case SearchType.GREEDY:
                path = Search.Greedy(graph, endingNode, printEnqueueCount, startingNode);
                break;
            default:
                path = null;
                break;
        }
        return path;
    }
}
