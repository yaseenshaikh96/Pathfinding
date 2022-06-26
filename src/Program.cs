public enum SearchType { BFS, DFS, GREEDY, ASTAR }

public class Program
{
    private delegate List<Graph<T>.Node>? SearchFuncT<T>(
        Graph<T> graph,
        Graph<T>.Node endingNode,
        bool printEnqueueCount,
        Graph<T>.Node? startingNode = null);

    private static SearchFuncT<int>[] SearchFuncs = new SearchFuncT<int>[4];

    private static SearchType searchType = SearchType.GREEDY;
    private static bool printEnqueueCount = true;

    public static void Main(string[] args)
    {
        InitializeFuncArray();

        Graph<int>? graph = ExampleGraph.ExampleGraph6();
        if (graph == null)
        {
            System.Console.Write("Graph is null");
            return;
        }
        graph.PrintGraph();
        Graph<int>.Node? startingNode = null;
        Graph<int>.Node endingNode = graph.GetNodes()[7];

        System.Console.WriteLine("SearchType: " + searchType.ToString());

        var path = SearchFuncs[(int)searchType](graph, endingNode, printEnqueueCount, startingNode);
        if (path == null)
        {
            System.Console.Write("Path is null");
            return;
        }
        Graph<int>.PrintPath(path);
    }

    private static void InitializeFuncArray()
    {
        SearchFuncs[0] = Search.BFS;
        SearchFuncs[1] = Search.DFS;
        SearchFuncs[2] = Search.Greedy;
        SearchFuncs[3] = Search.AStar;
    }
}
