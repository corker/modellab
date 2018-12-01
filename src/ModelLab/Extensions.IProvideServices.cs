namespace ModelLab
{
    public static partial class Extensions
    {
        public static T Get<T>(this IProvideServices x)
        {
            return (T) x.Get(typeof(T));
        }
    }
}