using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Helpers;

namespace WebUI.Service
{
    public class AppService
    {

        public void SendAppVersion()
        {
            var version = AppHelpers.GetAppVersion();
        }
    }
}
