using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using ModelLab.Graphs;

namespace ModelLab.Graphml
{
    public class GraphmlNavigator : INavigateGraphs
    {
        private static readonly XmlNamespaceManager XmlNamespaceManager;
        private readonly IParseValues _values;

        private readonly XDocument _xDocument;
        private List<Edge> _edges;
        private List<Node> _nodes;

        static GraphmlNavigator()
        {
            var nameTable = new NameTable();
            XmlNamespaceManager = new XmlNamespaceManager(nameTable);
            XmlNamespaceManager.AddNamespace("a", "http://graphml.graphdrawing.org/xmlns");
            XmlNamespaceManager.AddNamespace("b", "http://www.yworks.com/xml/graphml");
        }

        public GraphmlNavigator(XDocument xDocument, IParseValues values)
        {
            _xDocument = xDocument;
            _values = values;
        }

        public IAmNode FindNode(string name)
        {
            Ensure();
            return _nodes.FirstOrDefault(x => x.Label == name);
        }

        public IEnumerable<IAmEdge> GetEdges(IAmNode node)
        {
            Ensure();
            return _edges.Where(x => x.SourceId == ((Node) node).Id);
        }

        public IAmNode FindTargetFor(IAmEdge edge)
        {
            Ensure();
            return _nodes.Single(x => x.Id == ((Edge) edge).TargetId);
        }

        private void Ensure()
        {
            if (_nodes != null) return;
            _nodes = new List<Node>();
            _edges = new List<Edge>();
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
            var label = xElement.XPathSelectElement(".//b:NodeLabel", XmlNamespaceManager)?.Value;
            var values = _values.Parse(label);
            var node = new Node
            {
                Id = xElement.Attribute("id")?.Value,
                Label = label,
                Values = values
            };
            _nodes.Add(node);
        }

        private void TryReadEdge(XElement xElement)
        {
            if (xElement.Name.LocalName != "edge") return;

            var label = xElement.XPathSelectElement(".//b:EdgeLabel", XmlNamespaceManager)?.Value;
            var values = _values.Parse(label);
            var edge = new Edge
            {
                Id = xElement.Attribute("id")?.Value,
                SourceId = xElement.Attribute("source")?.Value,
                TargetId = xElement.Attribute("target")?.Value,
                Label = label,
                Values = values
            };
            _edges.Add(edge);
        }

        private class Edge : IAmEdge, IProvideValues
        {
            public string Id { get; set; }
            public string Label { get; set; }
            public string SourceId { get; set; }
            public string TargetId { get; set; }
            public IProvideValues Values { get; set; }

            public T Find<T>() where T : class
            {
                return Values.Find<T>();
            }
        }

        private class Node : IAmNode, IProvideValues
        {
            public string Id { get; set; }
            public string Label { get; set; }
            public IProvideValues Values { get; set; }

            public T Find<T>() where T : class
            {
                return Values.Find<T>();
            }
        }
    }
}