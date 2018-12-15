using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace ModelLab.Graphml
{
    public class GraphmlModelReader : IReadStreams<GraphmlNavigator>
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

        public GraphmlNavigator ReadFrom(Stream stream)
        {
            using (var reader = XmlReader.Create(stream, XmlReaderSettings))
            {
                var xDocument = XDocument.Load(reader);
                return new GraphmlNavigator(xDocument);
            }
        }
    }
}