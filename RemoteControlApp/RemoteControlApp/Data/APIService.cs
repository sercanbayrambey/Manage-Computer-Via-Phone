using RemoteControlApp.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlApp.Data
{
    public class APIService : Services
    {
        public bool OpenSpotify()
        {
            try
            {
                return SendGetRequest(new Dictionary<string, string>
                {
                    {"spotify","spotify" }
                });
                 
            }
            catch
            {
                return false;
            }
        }

        public bool ShutDownPC()
        {
            try
            {
                return SendGetRequest(new Dictionary<string, string>
                {
                    {"turnOff","turnOff" }
                });

            }
            catch
            {
                return false;
            }

        }


        public bool SwitchSleepMode()
        {
            try
            {
                return SendGetRequest(new Dictionary<string, string>
                {
                    {"switchSleepMode","switchSleepMode" }
                });

            }
            catch
            {
                return false;
            }
        
        }


        public bool CheckServerStatus()
        {
            try
            {
                return SendGetRequest(new Dictionary<string, string>
                {
                    {"status","status" }
                });

            }
            catch
            {
                return false;
            }

        }



        public bool SendGetRequest (Dictionary<string, string> parameters)
        {

            try
            {
                var client = new RestClient(StaticVariables.APIURL);

                var request = new RestRequest(Method.GET);
                request.Timeout = 5000;
                request.AddParameter(parameters.ElementAt(0).Key, parameters.ElementAt(0).Value);
                var response = client.Execute(request);
                if (response.StatusCode != HttpStatusCode.OK)
                    return false;
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool MuteUnmuteSound()
        {
            try
            {
                return SendGetRequest(new Dictionary<string, string>
                {
                    {"soundMuteUnmute","soundMuteUnmute" }
                });

            }
            catch
            {
                return false;
            }
        }

        public bool VolumeUp()
        {
            try
            {
                return SendGetRequest(new Dictionary<string, string>
                {
                    {"volumeUp","volumeUp" }
                });

            }
            catch
            {
                return false;
            }
        }

        public bool VolumeDown()
        {
            try
            {
                return SendGetRequest(new Dictionary<string, string>
                {
                    {"volumeDown","volumeDown" }
                });

            }
            catch
            {
                return false;
            }
        }
    }
}
