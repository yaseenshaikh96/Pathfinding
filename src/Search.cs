public static class Search
{
    public static List<Graph<T>.Node>? Greedy<T>(
        Graph<T> graph,
        Graph<T>.Node endingNode,
        bool printEnqueueCount,
        Graph<T>.Node? startingNode = null)
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
            List<List<Graph<T>.Node>> newPaths = new List<List<Graph<T>.Node>>();

            System.Console.Write("CurrentPath: ");
            Graph<T>.PrintPath(currentPath);

            foreach (var connection in currentPath[currentPath.Count - 1].connections)
            {
                if (visited.Contains(connection.node))
                    continue;
                visited.Add(connection.node);
                List<Graph<T>.Node> newPath = new List<Graph<T>.Node>(currentPath);
                newPath.Add(connection.node);
                if (newPath[newPath.Count - 1] == endingNode)
                {
                    if (printEnqueueCount) System.Console.WriteLine("EnqueueCount: " + enqueueCount);
                    return newPath;
                }
                newPaths.Add(newPath);
                enqueueCount++;
            }
            var newPathsArr = MySort(newPaths);
            foreach (var newPath in newPathsArr)
                pathList.Add(newPath);
        }
        return null;

        static List<Graph<T>.Node>[] MySort(List<List<Graph<T>.Node>> list)
        {
            (List<Graph<T>.Node>, float)[] weightedPaths = new (List<Graph<T>.Node>, float)[list.Count];
            // foreach (List<Graph<T>.Node> newPath in list)
            for (int i2 = 0; i2 < list.Count; i2++)
            {
                var newPath = list[i2];
                float totalPathAmount = 0;
                for (int i = 0; i < newPath.Count - 1; i++)
                {
                    float? weight = newPath[i].GetConnectionWeight(newPath[i + 1]);
                    totalPathAmount += weight == null ? 0 : (float)weight;
                }
                weightedPaths[i2] = ((newPath, totalPathAmount));
            }

            for (int i = 0; i < weightedPaths.Length - 1; i++)
                for (int j = 0; j < weightedPaths.Length - i - 1; j++)
                    if (weightedPaths[j].Item2 > weightedPaths[j + 1].Item2)
                    {
                        var temp = weightedPaths[j];
                        weightedPaths[j] = weightedPaths[j + 1];
                        weightedPaths[j + 1] = temp;
                    }

            List<List<Graph<T>.Node>> weightedPathsList = new List<List<Graph<T>.Node>>();
            foreach (var weightedPath in weightedPaths)
                weightedPathsList.Add(weightedPath.Item1);

            return weightedPathsList.ToArray();
        }
    }

    public static List<Graph<T>.Node>? BFS<T>(
        Graph<T> graph,
        Graph<T>.Node endingNode,
        bool printEnqueueCount,
        Graph<T>.Node? startingNode = null)
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
                    if (printEnqueueCount) System.Console.WriteLine("EnqueueCount: " + enqueueCount);
                    return newPath;
                }
                pathList.Add(newPath);

                enqueueCount++;
            }
        }
        return null;
    }

    public static List<Graph<T>.Node>? DFS<T>(
        Graph<T> graph,
        Graph<T>.Node endingNode,
        bool printEnqueueCount,
        Graph<T>.Node? startingNode = null)
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
                    if (printEnqueueCount) System.Console.WriteLine("EnqueueCount: " + enqueueCount);
                    return newPath;
                }
                pathList.Insert(0, newPath);

                enqueueCount++;
            }
        }
        return null;
    }


}