using System.IO;
using System.Xml;
using System.Xml.Linq;
using ModelLab.Infrastructure;

namespace ModelLab.Graphml
{
    public class GraphmlModelReader : IReadStreams<GraphmlNavigator>
    {
        private static readonly XmlReaderSettings XmlReaderSettings;

        private readonly IWriteLogs _logs;
        private readonly IParseValues _values;

        static GraphmlModelReader()
        {
            XmlReaderSettings = new XmlReaderSettings
            {
                IgnoreWhitespace = true
            };
        }

        public GraphmlModelReader(IWriteLogs logs, IParseValues values)
        {
            _logs = logs;
            _values = values;
        }

        public GraphmlNavigator ReadFrom(Stream stream)
        {
            using (var reader = XmlReader.Create(stream, XmlReaderSettings))
            {
                var xDocument = XDocument.Load(reader);
                return new GraphmlNavigator(xDocument, _values);
            }
        }
    }
}