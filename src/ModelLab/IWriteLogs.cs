namespace ModelLab
{
    public interface IWriteLogs
    {
        void Write(string format, params object[] args);
    }
}