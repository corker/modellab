using System.IO;

namespace ModelLab.Infrastructure
{
    public interface IReadStreams<out T>
    {
        T ReadFrom(Stream stream);
    }
}