using RemoteControlApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControlApp.Data
{
    public class ServiceManager : Services,IDisposable
    {
        public bool CheckServerStatus()
        {
            APIService APIService = new APIService();
            return APIService.CheckServerStatus();
        }

        public void Dispose()
        {
        }

        public bool MuteUnmuteSound()
        {
            APIService APIService = new APIService();
            return APIService.MuteUnmuteSound();
        }

        public bool OpenSpotify()
        {
            APIService APIService = new APIService();
            return APIService.OpenSpotify();
        }

        public bool ShutDownPC()
        {
            APIService APIService = new APIService();
            return APIService.ShutDownPC();
        }

        public bool SwitchSleepMode()
        {
            APIService APIService = new APIService();
            return APIService.SwitchSleepMode();
        }

        public bool VolumeDown()
        {
            APIService APIService = new APIService();
            return APIService.VolumeDown();
        }

        public bool VolumeUp()
        {
            APIService APIService = new APIService();
            return APIService.VolumeUp();
        }
    }
}
