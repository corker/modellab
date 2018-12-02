using System.IO;

namespace ModelLab
{
    public interface IReadStreams<out T>
    {
        T ReadFrom(Stream stream);
    }
}