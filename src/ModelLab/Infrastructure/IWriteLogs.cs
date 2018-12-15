namespace ModelLab.Infrastructure
{
    public interface IWriteLogs
    {
        void Write(string format, params object[] args);
    }
}