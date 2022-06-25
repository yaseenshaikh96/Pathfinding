public static class Search
{
    public static List<Graph<T>.Node>? BFS<T>(Graph<T> graph, Graph<T>.Node endingNode, Graph<T>.Node? startingNode = null)
    {
        int enqueueCount = 0;
        if (startingNode == null)
            startingNode = graph.GetNodes()[0];

        List<Graph<T>.Node> visited = new List<Graph<T>.Node>();
        List<List<Graph<T>.Node>> pathList = new List<List<Graph<T>.Node>>();
        List<Graph<T>.Node> startingPath = new List<Graph<T>.Node>();
        startingPath.Add(startingNode);
        pathList.Add(startingPath);

        while (pathList.Count > 0)
        {
            List<Graph<T>.Node> currentPath = pathList[0];
            pathList.RemoveAt(0);

            foreach (var connection in currentPath[currentPath.Count - 1].connections)
            {
                if (visited.Contains(connection.node))
                    continue;
                visited.Add(connection.node);
                List<Graph<T>.Node> newPath = new List<Graph<T>.Node>(currentPath);
                newPath.Add(connection.node);
                if (newPath[newPath.Count - 1] == endingNode)
                    return newPath;
                pathList.Add(newPath);

                enqueueCount++;
            }
        }
        return null;
    }

    public static List<Graph<T>.Node>? DFS<T>(Graph<T> graph, Graph<T>.Node endingNode, Graph<T>.Node? startingNode = null)
    {
        int enqueueCount = 0;
        if (startingNode == null)
            startingNode = graph.GetNodes()[0];

        List<Graph<T>.Node> visited = new List<Graph<T>.Node>();
        List<List<Graph<T>.Node>> pathList = new List<List<Graph<T>.Node>>();
        List<Graph<T>.Node> startingPath = new List<Graph<T>.Node>();
        startingPath.Add(startingNode);
        pathList.Add(startingPath);

        while (pathList.Count > 0)
        {
            List<Graph<T>.Node> currentPath = pathList[0];
            pathList.RemoveAt(0);

            foreach (var connection in currentPath[currentPath.Count - 1].connections)
            {
                if (visited.Contains(connection.node))
                    continue;
                visited.Add(connection.node);
                List<Graph<T>.Node> newPath = new List<Graph<T>.Node>(currentPath);
                newPath.Add(connection.node);
                if (newPath[newPath.Count - 1] == endingNode)
                {
                    System.Console.Write("enqueueCount: " + enqueueCount + '\n');
                    return newPath;
                }
                pathList.Insert(0, newPath);

                enqueueCount++;
            }
        }
        return null;
    }


}