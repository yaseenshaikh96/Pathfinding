public static class Search
{
    public static List<Graph<T>.Node>? AStar<T>(
        Graph<T> graph,
        Graph<T>.Node endingNode,
        bool printEnqueueCount,
        Graph<T>.Node? startingNode = null)
    {
        return null;
    }

    public static List<Graph<T>.Node>? Greedy<T>(
        Graph<T> graph,
        Graph<T>.Node endingNode,
        bool printEnqueueCount,
        Graph<T>.Node? startingNode = null)
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

            System.Console.Write("CurrentPath: ");
            Graph<T>.PrintPath(currentPath);

            foreach (var connection in currentPath[currentPath.Count - 1].connections)
            {
                if (currentPath.Contains(connection.node))
                    continue; // dont go back up the tree

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
            MySort(pathList); // shortest path first
        }
        return null;

        static void MySort(List<List<Graph<T>.Node>> pathList)
        {
            float[] pathWeights = new float[pathList.Count];
            for (int i2 = 0; i2 < pathList.Count; i2++)
            {
                var newPath = pathList[i2];
                float totalPathAmount = 0;
                for (int i = 0; i < newPath.Count - 1; i++)
                {
                    float? weight = newPath[i].GetConnectionWeight(newPath[i + 1]);
                    totalPathAmount += weight == null ? 0 : (float)weight;
                }
                pathWeights[i2] = totalPathAmount;
            }

            for (int i = 0; i < pathWeights.Length - 1; i++)
                for (int j = 0; j < pathWeights.Length - i - 1; j++)
                    if (pathWeights[j] > pathWeights[j + 1])
                    {
                        Swap(ref pathWeights[j], ref pathWeights[j + 1]);
                        var temp2 = pathList[j];
                        pathList[j] = pathList[j + 1];
                        pathList[j + 1] = temp2;
                    }

            static void Swap<U>(ref U obj1, ref U obj2)
            {
                var temp2 = obj1;
                obj1 = obj2;
                obj2 = temp2;
            }
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
                if (currentPath.Contains(connection.node))
                    continue; // dont go back up the tree

                List<Graph<T>.Node> newPath = new List<Graph<T>.Node>(currentPath);
                newPath.Add(connection.node);
                if (newPath[newPath.Count - 1] == endingNode)
                {
                    if (printEnqueueCount) System.Console.WriteLine("EnqueueCount: " + enqueueCount);
                    return newPath;
                }
                pathList.Add(newPath); // added at last, removed from front. A Queue 

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
                if (currentPath.Contains(connection.node))
                    continue; // dont go back up the tree

                List<Graph<T>.Node> newPath = new List<Graph<T>.Node>(currentPath);
                newPath.Add(connection.node);
                if (newPath[newPath.Count - 1] == endingNode)
                {
                    if (printEnqueueCount) System.Console.WriteLine("EnqueueCount: " + enqueueCount);
                    return newPath;
                }
                pathList.Insert(0, newPath); // added at front, removed at front. A Stack

                enqueueCount++;
            }
        }
        return null;
    }


}