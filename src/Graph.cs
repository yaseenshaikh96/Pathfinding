public class Graph<T>
{
    private List<Node> nodes;

    public Graph()
    {
        this.nodes = new List<Node>();
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
            nodeList.Add(CreateNode(i.ToString()));
        return nodeList.ToArray();
    }

    public Graph<T>.Node[] GetNodes() => nodes.ToArray();

    public void Connect(Node connector, params Connection[] connections)
    {
        // if (!nodes.Contains(connector)) { PrintError("Node to connect not in graph"); return; }
        // foreach (Connection connection in connections)
        // {
        //     Node neighbourNode = connection.node;
        //     if (connector == neighbourNode) { PrintError("node cannot connect to itself"); continue; }
        //     if (connector.IsConnected(neighbourNode)) { PrintError("connecting an already connected node"); continue; }
        //     if (!nodes.Contains(neighbourNode)) { PrintError("connecting node which is not in graph"); continue; }

        //     connector.connections.Add(new Connection(neighbourNode, connection.weight));
        //     neighbourNode.connections.Add(new Connection(connector, connection.weight));
        // }
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
            Connect(connector, connectingNode, 0);
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

    public void PrintGraph()
    {
        System.Console.Write($"# of nodes: {nodes.Count}\n");
        foreach (var node in nodes)
        {
            System.Console.Write("Name: " + node.name + ", ");
            System.Console.Write("Data: " + node.data + ", ");
            System.Console.Write("Connections: ");
            foreach (Graph<T>.Connection connection in node.connections)
                System.Console.Write($"({connection.node.name}, {connection.weight})");
            // System.Console.Write("weight: " + connection.weight + ", For: " + connection.node.name + ", ");

            System.Console.Write("\n");
        }
    }

    private static void PrintError(string err)
    {
        System.Console.ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine(err);
        System.Console.ResetColor();
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
    }

    public class Connection
    {
        public Node node;
        public float weight;

        public Connection(Node neighbour, float weight = 1)
        {
            this.node = neighbour;
            this.weight = weight;
        }

    }
}