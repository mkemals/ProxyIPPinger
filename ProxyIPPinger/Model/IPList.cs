using System.Drawing;

namespace ProxyIPPinger.Model
{
    public class IPList
    {
        public string IP { get; set; } = "0.0.0.0";
        public bool Enable { get; set; } = true;
        public byte Status { get; set; } = 0;
        public Image StatusImage { get; set; }
        public int FailCount { get; set; } = 0;
        public int UseCount { get; set; } = 0;
        public int PingCount { get; set; } = 0;
        public bool InUse { get; set; } = false;
    }
}
