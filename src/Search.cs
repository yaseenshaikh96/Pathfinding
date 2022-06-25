public static class Search
{
    public static List<Graph<T>.Node>? BFS<T>(Graph<T> graph, Graph<T>.Node endingNode, Graph<T>.Node? startingNode = null)
    {
        int enqueueCount = 0;
        if (startingNode == null)
            startingNode = graph.GetNodes()[0];

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
                List<Graph<T>.Node> newPath = new List<Graph<T>.Node>(currentPath);
                newPath.Add(connection.node);
                if (newPath[newPath.Count - 1] == endingNode)
                {
                    // System.Console.Write("EnqueueCount: " + enqueueCount);
                    return newPath;
                }
                if (currentPath.Count == 1)                                 // all this to not
                {                                                           // add parent node
                    pathList.Insert(0, newPath);                            // to new path.
                    continue;                                               //
                }                                                           //
                if (connection.node != currentPath[currentPath.Count - 2])  //
                    pathList.Insert(0, newPath);                            //

                enqueueCount++;
            }
        }
        return null;
    }


}