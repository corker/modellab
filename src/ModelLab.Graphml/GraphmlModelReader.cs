using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ModelLab.Graphml
{
    public class GraphmlModelReader : IReadStreams<GraphmlGraph>
    {
        private static readonly XmlReaderSettings XmlReaderSettings;

        private readonly IWriteLogs _logs;

        static GraphmlModelReader()
        {
            XmlReaderSettings = new XmlReaderSettings
            {
                IgnoreWhitespace = true
            };
        }

        public GraphmlModelReader(IWriteLogs logs)
        {
            _logs = logs;
        }

        public GraphmlGraph ReadFrom(Stream stream)
        {
            using (var reader = XmlReader.Create(stream, XmlReaderSettings))
            {
                var xDocument = XDocument.Load(reader);
                return new GraphmlGraph(xDocument);
            }
        }
    }
}