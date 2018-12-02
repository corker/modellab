using System.Collections.Generic;

namespace ModelLab.Graphml
{
    public class GraphmlModel : IAmModel
    {
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }
    }
}