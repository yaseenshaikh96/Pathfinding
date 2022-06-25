public class GraphData
{
    int numOfNodes;
    public float[,] values;
    public GraphData(int numOfNodes, params float[] weights)
    {
        this.numOfNodes = numOfNodes;
        values = new float[numOfNodes, numOfNodes];
        for (int i = 0; i < weights.Length; i++)
        {
            int x = i / numOfNodes;
            int y = i % numOfNodes;
            values[x, y] = weights[i];
        }
    }

    public void Print()
    {
        for (int x = 0; x < numOfNodes; x++)
        {
            for (int y = 0; y < numOfNodes; y++)
            {
                System.Console.Write(values[x, y] + ", ");
            }
            System.Console.Write('\n');
        }
    }
}