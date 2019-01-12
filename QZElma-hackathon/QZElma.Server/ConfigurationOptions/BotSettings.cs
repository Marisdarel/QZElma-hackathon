using System;
using System.Collections.Generic;
using System.Text;

namespace QZElma.Server.ConfigurationOptions
{
    public class BotSettings
    {
        public string Type { get; set; }
        public string Token { get; set; }
        public string HoockUrl {get;set;}
        public string Socks5Host { get; set; }
        public int Socks5Port { get; set; }
        public string Socks5User { get; set; }
        public string Socks5Pass { get; set; }
    }
}
