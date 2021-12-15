
public class Node 
{
    public string Name { get; private set; }
    public bool Visited { get; private set; }

    public List<Node>? Leaves {get; set;}
    public Node(string name)
    {
        Name = name;
        Visited = false;
    }
}



