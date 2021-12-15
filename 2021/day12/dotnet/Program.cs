var sample = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

var nodes = new List<Node>();

// create the nodes :)

// maybe lets take a fresh look at somepoint - maybe in the morning?
sample.Split("\n").Select(x => x.Trim()).Select(s => s.Split('-')).ToList().ForEach(cave => {

    var node2 = nodes.FirstOrDefault(node => node.Name == cave[1]);
    var node1 = nodes.FirstOrDefault(node => node.Name == cave[0]);
});

