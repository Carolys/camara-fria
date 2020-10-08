using CamaraFria.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace CamaraFria.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private Camara _Camara;
        public Camara Camara
        {
            get { return _Camara; }
            set { SetProperty(ref _Camara, value); }
        }
        private string _Lampada;
        public string Lampada
        {
            get { return _Lampada; }
            set { SetProperty(ref _Lampada, value); }
        }
        private string _TxtColor;
        public string TxtColor
        {
            get { return _TxtColor; }
            set { SetProperty(ref _TxtColor, value); }
        }
        private string _Led1;
        public string Led1
        {
            get { return _Led1; }
            set { SetProperty(ref _Led1, value); }
        }
        private string _Led2;
        public string Led2
        {
            get { return _Led2; }
            set { SetProperty(ref _Led2, value); }
        }
        private string _BackgroundColor;
        public string BackgroundColor
        {
            get { return _BackgroundColor; }
            set { SetProperty(ref _BackgroundColor, value); }
        }
        private string _Temperatura;
        public string Temperatura
        {
            get { return _Temperatura; }
            set { SetProperty(ref _Temperatura, value); }
        }
        private int intervalInSeconds;
        public Command ModifyDataCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            this.intervalInSeconds = 1;
            GetData();
            ModifyDataCommand = new Command(async () => await ExecuteModifyDataCommandCommand());
            Device.StartTimer(TimeSpan.FromSeconds(this.intervalInSeconds), () =>
            {
                Device.BeginInvokeOnMainThread(() => GetData());
                return true;
            });            
        }

        private void GetData()
        {
            string URL = "https://camara-fria.firebaseio.com/.json";
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URL);
            request1.ContentType = "application/json: charset-utf-8";
            HttpWebResponse response1 = request1.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response1.GetResponseStream())
            {
                StreamReader Read = new StreamReader(responseStream, Encoding.UTF8);
                var content = Read.ReadToEnd();
                var data = JObject.Parse(content);                
                Camara = JsonConvert.DeserializeObject<Camara>(data.ToString());
            }

            if(Camara != null)
            {
                Temperatura = Camara.Temperatura + "°C";
                if (Camara.Lampada == "LIGADO")
                {
                    Lampada = "luminaria_ligada.png";
                    TxtColor = "#383838";
                    BackgroundColor = "#FFFFFF";
                }
                else
                {
                    Lampada = "luminaria_desligada.png";
                    TxtColor = "#FFFFFF";
                    BackgroundColor = "#30314F";
                }

                if(Camara.Led1 == "LIGADO")
                {
                    Led1 = "led_verde.png";
                    Led2 = "led_desligada.png";
                }
                else
                {
                    Led1 = "led_desligada.png";
                    Led2 = "led_vermelha.png";
                }

    
            }
        }

        private async Task ExecuteModifyDataCommandCommand()
        {
            string lamp = "";
            if (Camara.Lampada == "DESLIGADO")
                lamp = "LIGADO";
            else
                lamp = "DESLIGADO";

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                lampada = lamp
            });

            var request = WebRequest.CreateHttp("https://camara-fria.firebaseio.com/.json");
            request.Method = "PATCH";
            request.ContentType = "application/json";
            var buffer = Encoding.UTF8.GetBytes(json);
            request.ContentLength = buffer.Length;
            request.GetRequestStream().Write(buffer, 0, buffer.Length);
            var response = request.GetResponse();
            json = (new StreamReader(response.GetResponseStream())).ReadToEnd();            
        }
    }
}
