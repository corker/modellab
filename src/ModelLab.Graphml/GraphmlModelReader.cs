using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace ModelLab.Graphml
{
    public class GraphmlModelReader : IReadStreams<GraphmlModel>
    {
        private static readonly XmlReaderSettings XmlReaderSettings;
        private static readonly XmlNamespaceManager XmlNamespaceManager;

        private readonly IWriteLogs _logs;

        static GraphmlModelReader()
        {
            XmlReaderSettings = new XmlReaderSettings
            {
                IgnoreWhitespace = true
            };
            var nameTable = new NameTable();
            XmlNamespaceManager = new XmlNamespaceManager(nameTable);
            XmlNamespaceManager.AddNamespace("a", "http://graphml.graphdrawing.org/xmlns");
            XmlNamespaceManager.AddNamespace("b", "http://www.yworks.com/xml/graphml");
        }

        public GraphmlModelReader(IWriteLogs logs)
        {
            _logs = logs;
        }

        public GraphmlModel ReadFrom(Stream stream)
        {
            var model = new GraphmlModel
            {
                Edges = new List<Edge>(),
                Nodes = new List<Node>()
            };

            using (var reader = XmlReader.Create(stream, XmlReaderSettings))
            {
                var xDocument = XDocument.Load(reader);
                xDocument
                    .XPathSelectElements("/a:graphml/a:graph/*", XmlNamespaceManager)
                    .Aggregate(model, (x, y) =>
                    {
                        TryReadEdge(x, y);
                        TryReadNode(x, y);
                        return x;
                    });
            }

            return model;
        }

        private static void TryReadNode(GraphmlModel model, XElement xElement)
        {
            if (xElement.Name != (XNamespace) "http://graphml.graphdrawing.org/xmlns" + "node") return;
            var node = new Node
            {
                Id = xElement.Attribute("id")?.Value,
                Label = xElement.XPathSelectElement("//b:NodeLabel", XmlNamespaceManager)?.Value
            };
            model.Nodes.Add(node);
        }

        private static void TryReadEdge(GraphmlModel model, XElement xElement)
        {
            if (xElement.Name != (XNamespace) "http://graphml.graphdrawing.org/xmlns" + "edge") return;
            var edge = new Edge
            {
                Id = xElement.Attribute("id")?.Value,
                SourceId = xElement.Attribute("source")?.Value,
                TargetId = xElement.Attribute("target")?.Value,
                Label = xElement.XPathSelectElement("//b:NodeLabel", XmlNamespaceManager)?.Value
            };
            model.Edges.Add(edge);
        }
    }
}