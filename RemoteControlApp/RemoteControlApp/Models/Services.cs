using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteControlApp.Models
{
    public interface Services
    {
        bool OpenSpotify();

        bool ShutDownPC();

        bool SwitchSleepMode();
        bool CheckServerStatus();
        bool MuteUnmuteSound();
        bool VolumeUp();
        bool VolumeDown();

    }
}
