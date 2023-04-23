using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level2_Task1.Utilities
{
    public class ReadFile
    {
        public static ISettingsFile getFile(String path)
        {
            ISettingsFile config = new JsonSettingsFile(path);
            return config;
        }
    }
}
