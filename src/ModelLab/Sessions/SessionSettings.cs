namespace ModelLab.Sessions
{
    public class SessionSettings : IProvideSessionSettings
    {
        public SessionSettings()
        {
            StartNodeName = "Start";
        }

        public string StartNodeName { get; set; }
    }
}