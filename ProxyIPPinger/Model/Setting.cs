namespace ProxyIPPinger.Model
{
    public class Setting
    {
        public int TimerInterval { get; set; } = 60;
        public bool PingForUsedIPOnly { get; set; } = false;
        public bool AutoChangeProxy { get; set; } = false;

        public bool _HasChanged { get; set; } = false;
    }
}
