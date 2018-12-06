using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ModelLab.Graphml
{
    public class GraphmlGraph : IAmGraph
    {
        private static readonly XmlNamespaceManager XmlNamespaceManager;

        private readonly XDocument _xDocument;
        private List<IAmGraphEdge> _edges;
        private List<IAmGraphNode> _nodes;

        static GraphmlGraph()
        {
            var nameTable = new NameTable();
            XmlNamespaceManager = new XmlNamespaceManager(nameTable);
            XmlNamespaceManager.AddNamespace("a", "http://graphml.graphdrawing.org/xmlns");
            XmlNamespaceManager.AddNamespace("b", "http://www.yworks.com/xml/graphml");
        }

        public GraphmlGraph(XDocument xDocument)
        {
            _xDocument = xDocument;
        }

        IEnumerable<IAmGraphNode> IAmGraph.Nodes
        {
            get
            {
                Ensure();
                return _nodes;
            }
        }

        IEnumerable<IAmGraphEdge> IAmGraph.Edges
        {
            get
            {
                Ensure();
                return _edges;
            }
        }

        private void Ensure()
        {
            if (_nodes != null) return;
            _nodes = new List<IAmGraphNode>();
            _edges = new List<IAmGraphEdge>();
            var xElements = _xDocument.XPathSelectElements("/a:graphml/a:graph/*", XmlNamespaceManager);
            foreach (var xElement in xElements)
            {
                TryReadEdge(xElement);
                TryReadNode(xElement);
            }
        }

        private void TryReadNode(XElement xElement)
        {
            if (xElement.Name.LocalName != "node") return;
            var node = new Node
            {
                Id = xElement.Attribute("id")?.Value,
                Label = xElement.XPathSelectElement("//b:NodeLabel", XmlNamespaceManager)?.Value
            };
            _nodes.Add(node);
        }

        private void TryReadEdge(XElement xElement)
        {
            if (xElement.Name.LocalName != "edge") return;
            var edge = new Edge
            {
                Id = xElement.Attribute("id")?.Value,
                SourceId = xElement.Attribute("source")?.Value,
                TargetId = xElement.Attribute("target")?.Value,
                Label = xElement.XPathSelectElement("//b:NodeLabel", XmlNamespaceManager)?.Value
            };
            _edges.Add(edge);
        }

        private class Edge : IAmGraphEdge
        {
            public string Id { get; set; }
            public string Label { get; set; }
            public string SourceId { get; set; }
            public string TargetId { get; set; }
        }

        private class Node : IAmGraphNode
        {
            public string Id { get; set; }
            public string Label { get; set; }
        }
    }
}