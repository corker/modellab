using System;
using System.IO;
using System.Xml;

namespace ModelLab.Graphml
{
    public class GraphmlModelReader : IReadStreams<GraphmlModel>
    {
        private readonly IWriteLogs _logs;

        public GraphmlModelReader(IWriteLogs logs)
        {
            _logs = logs;
        }

        public GraphmlModel ReadFrom(Stream stream)
        {
            using (var reader = XmlReader.Create(stream))
            {
                while (reader.Read())
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            _logs.Write("<{0}>", reader.Name);
                            break;
                        case XmlNodeType.Text:
                            _logs.Write(reader.Value);
                            break;
                        case XmlNodeType.CDATA:
                            _logs.Write("<![CDATA[{0}]]>", reader.Value);
                            break;
                        case XmlNodeType.ProcessingInstruction:
                            _logs.Write("<?{0} {1}?>", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.Comment:
                            _logs.Write("<!--{0}-->", reader.Value);
                            break;
                        case XmlNodeType.XmlDeclaration:
                            _logs.Write("<?xml version='1.0'?>");
                            break;
                        case XmlNodeType.Document:
                            break;
                        case XmlNodeType.DocumentType:
                            _logs.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                            break;
                        case XmlNodeType.EntityReference:
                            _logs.Write(reader.Name);
                            break;
                        case XmlNodeType.EndElement:
                            _logs.Write("</{0}>", reader.Name);
                            break;
                        case XmlNodeType.Attribute:
                            break;
                        case XmlNodeType.DocumentFragment:
                            break;
                        case XmlNodeType.EndEntity:
                            break;
                        case XmlNodeType.Entity:
                            break;
                        case XmlNodeType.None:
                            break;
                        case XmlNodeType.Notation:
                            break;
                        case XmlNodeType.SignificantWhitespace:
                            break;
                        case XmlNodeType.Whitespace:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
            }

            return new GraphmlModel();
        }
    }
}