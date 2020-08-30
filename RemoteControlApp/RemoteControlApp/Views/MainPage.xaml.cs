using RemoteControlApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RemoteControlApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Task.Run(() => CheckServerStatus());
        }

        private void btnSpotify_Clicked(object sender, EventArgs e)
        {
            using (ServiceManager sm = new ServiceManager())
            {
                if (sm.OpenSpotify())
                    DisplayAlert("Başarılı", "İşlem başarılı", "OK");
                else
                    DisplayAlert("Başarısız", "İşlem başarısız!", "OK");
            }
                
        }

        private void btnVolumeDown_Clicked(object sender, EventArgs e)
        {
            btnVolumeDown.IsEnabled = false;
            using (ServiceManager sm = new ServiceManager())
            {
                sm.VolumeDown();
            }
            btnVolumeDown.IsEnabled = true;
        }

        private void btnVolumeUp_Clicked(object sender, EventArgs e)
        {
            btnVolumeUp.IsEnabled = false;
            using (ServiceManager sm = new ServiceManager())
            {

                sm.VolumeUp();
            }
            btnVolumeUp.IsEnabled = true;

        }

        private void btnMuteUnmute_Clicked(object sender, EventArgs e)
        {
            using (ServiceManager sm = new ServiceManager())
            {
                if (sm.MuteUnmuteSound())
                    DisplayAlert("Başarılı", "İşlem başarılı", "OK");
                else
                    DisplayAlert("Başarısız", "İşlem başarısız!", "OK");
            }

        }

        private async void btnTurnOff_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Emin misiniz?", "Bu işlemi yapmaya emin misiniz: Kapat", "Evet", "Hayır");
            if (!result)
                return;

            using (ServiceManager sm = new ServiceManager())
            {
                if (sm.ShutDownPC())
                    await DisplayAlert("Başarılı", "İşlem başarılı", "OK");
                else
                    await DisplayAlert("Başarısız", "İşlem başarısız!", "OK");
            }
        }

        private async void btnTurnSleep_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert("Emin misiniz?", "Bu işlemi yapmaya emin misiniz: Uyku Modu", "Evet", "Hayır");
            if(!result)
                return;

            using (ServiceManager sm = new ServiceManager())
            {
                if (sm.SwitchSleepMode())
                    await DisplayAlert("Başarılı", "İşlem başarılı", "OK");
                else
                   await DisplayAlert("Başarısız", "İşlem başarısız!", "OK");
            }
        }

        private async void btnServerStatus_Clicked(object sender, EventArgs e)
        {
            await Task.Run(()=>CheckServerStatus());
        }


        private void CheckServerStatus()
        {
            Device.BeginInvokeOnMainThread(() => {
                lblServerStatus.Text = "Bilgisayar: Kontrol ediliyor...";
                frameServerStatus.BackgroundColor = Color.LightGray;
            });
            using (ServiceManager sm = new ServiceManager())
            {
                if (sm.CheckServerStatus())
                {
                    Device.BeginInvokeOnMainThread(() => {
                        lblServerStatus.Text = "Bilgisayar: AÇIK";
                        frameServerStatus.BackgroundColor = Color.FromHex("#1DB954");
                    });

                }
                else
                {
                    Device.BeginInvokeOnMainThread(() => {
                        lblServerStatus.Text = "Bilgisayar: KAPALI";
                        frameServerStatus.BackgroundColor = Color.IndianRed;
                    });
                    
                }
            }
        }
    }
}
