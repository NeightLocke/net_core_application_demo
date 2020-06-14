using System;
using System.Collections.Generic;
using System.Text;

namespace SocialGames.TechnicalTest.Games.Model
{
    public class LoggingConfiguration
    {
        public string PathLogBase { get; set; }
        public string NormalLogSufix { get; set; }
        public string ErrorsLogSufix { get; set; }
        public string DefaultExtensionFile { get; set; }
        public string MinimumLevel { get; set; }
    }
}