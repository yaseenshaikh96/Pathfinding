public class Graph<T>
{
    public const int defaultWeight = 1;
    private List<Node> nodes;

    public Graph()
    {
        this.nodes = new List<Node>();
    }
    public Graph(GraphData graphData)
    {
        this.nodes = new List<Node>();
        int numOfNodes = graphData.values.GetLength(0);
        CreateNodeMulti(numOfNodes);
        if (nodes.Count < 1) { PrintError("GraphData empty"); return; }

        for (int x = 0; x < nodes.Count; x++)
            for (int y = 0; y < nodes.Count; y++)
                if (graphData.values[x, y] > 0)
                    Connect(nodes[x], nodes[y], graphData.values[x, y]);
    }

    public Node CreateNode(string nodeName, T? data = default(T), params Connection[] connections)
    {
        Node newNode = new Node(this, nodeName, data);
        Connect(newNode, connections);
        return newNode;
    }

    public Node[]? CreateNodeMulti(params string[] nodeNames)
    {
        if (nodeNames == null) return null;
        List<Node> nodelist = new List<Node>();
        foreach (string nodeName in nodeNames)
            nodelist.Add(CreateNode(nodeName));
        return nodelist.ToArray();
    }

    public Node[]? CreateNodeMulti(int numOfNodes)
    {
        if (numOfNodes < 1) { PrintError("cannot create non-positive number of nodes"); return null; }
        List<Node> nodeList = new List<Node>();
        for (int i = 0; i < numOfNodes; i++)
            nodeList.Add(CreateNode("Node" + i.ToString()));
        return nodeList.ToArray();
    }

    public Graph<T>.Node[] GetNodes() => nodes.ToArray();

    public void Connect(Node connector, params Connection[] connections)
    {
        if (!nodes.Contains(connector)) { PrintError("connecting node which is not in graph"); return; }
        foreach (Connection connection in connections)
        {
            Node neighbourNode = connection.node;
            Connect(connector, neighbourNode, connection.weight);
        }
    }

    public void Connect(Node node1, Node node2, float weight)
    {
        if (node1 == node2) { PrintError("Node connnot connect to itself"); return; }
        if (!nodes.Contains(node1) || !nodes.Contains(node2)) { PrintError("connecting node which is not in graph"); return; }
        if (!node1.IsConnected(node1))
            node1.connections.Add(new Connection(node2, weight));
        if (!node2.IsConnected(node1))
            node2.connections.Add(new Connection(node1, weight));
    }

    public void Connect(Node connector, params Node[] connecting)
    {
        foreach (var connectingNode in connecting)
            Connect(connector, connectingNode, defaultWeight);
    }

    public bool IsNodeInGraph(Node node)
    {
        return nodes.Contains(node);
    }

    public void DeleteNode(Node nodeToDelete)
    {
        if (!nodes.Contains(nodeToDelete)) { PrintError("node to delete is not in graph"); return; }
        nodes.Remove(nodeToDelete);

        foreach (Connection connections in nodeToDelete.connections)
        {
            List<Connection> connectionNeighbour = connections.node.connections;
            for (int i = 0; i < connectionNeighbour.Count; i++)
            {
                if (connectionNeighbour[i].node == nodeToDelete)
                    connectionNeighbour.Remove(connectionNeighbour[i]);
            }
            connections.node.connections = connectionNeighbour;
        }

        // if (IsGraphFragmented()) Utility.PrintError("graph got fragmented");
    }

    // public bool IsGraphFragmented()
    // {
    //     Node[] visited = BFS.Traverse<T>(this);
    //     return visited.Length != nodes.ToArray().Length;
    // }

    //--------------------------------------------------------------------------------------------//

    public void PrintGraph()
    {
        System.Console.Write($"# of nodes: {nodes.Count}\n");
        foreach (var node in nodes)
        {
            System.Console.Write("Name: ");
            PrintNodeName(node.name);
            System.Console.Write(", ");
            System.Console.Write("Data: ");
            PrintNodeData(node.data);
            System.Console.Write(", ");
            System.Console.Write("Connections: ");
            foreach (Graph<T>.Connection connection in node.connections)
                PrintConnection(connection);
            System.Console.Write("\n");
        }
        static void PrintConnection(Connection connection)
        {
            System.Console.Write("(");
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write(connection.node.name);
            System.Console.ResetColor();
            System.Console.Write(", ");
            System.Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.Write(connection.weight);
            System.Console.ResetColor();
            System.Console.Write(") ");
        }
    }
    private static void PrintNodeName(string nodeName)
    {
        System.Console.ForegroundColor = ConsoleColor.Green;
        System.Console.Write(nodeName);
        System.Console.ResetColor();
    }
    private static void PrintNodeData(T? data)
    {

        System.Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.Write(data?.ToString());
        System.Console.ResetColor();
    }

    private static void PrintError(string err)
    {
        System.Console.ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine(err);
        System.Console.ResetColor();
    }

    public static void PrintPath(List<Graph<T>.Node> path)
    {
        System.Console.Write("path: ");
        for (int i = 0; i < path.Count - 1; i++)
        {
            PrintNodeName(path[i].name);
            System.Console.Write(" -> ");
        }
        PrintNodeName(path[path.Count - 1].name);
        System.Console.Write('\n');
    }

    //---------------------------------------------------//

    public class Node
    {
        public string name;
        public List<Connection> connections;
        public T? data;

        public Node(Graph<T> graph, string name, T? data = default(T))
        {
            this.name = name;
            this.connections = new List<Connection>();
            this.data = data;
            graph.nodes.Add(this);
        }

        public bool IsConnected(Node node)
        {
            foreach (Connection connection in connections)
            {
                if (connection.node == node)
                    return true;
            }
            return false;
        }
        public bool IsDataEqual(Node node2)
        {
            return EqualityComparer<T>.Default.Equals(this.data, node2.data);
        }

        public float? GetConnectionWeight(Node node2)
        {
            foreach (Connection connection in connections)
                if (connection.node == node2)
                    return connection.weight;
            return null;
        }
    }

    public class Connection
    {
        public Node node;
        public float weight;

        public Connection(Node neighbour, float weight = defaultWeight)
        {
            this.node = neighbour;
            this.weight = weight;
        }

    }
}