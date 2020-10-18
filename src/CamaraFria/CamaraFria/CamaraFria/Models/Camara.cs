using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CamaraFria.Models
{
    public class Camara
    {
        //"{\"lampada\":\"DESLIGADO\",\"led1\":\"LIGADO\",\"led2\":\"DESLIGADO\",\"temperatura\":0}"
        [JsonProperty("lampada")]
        public string Lampada { get; set; }
        [JsonProperty("led1")]
        public string Led1 { get; set; }
        [JsonProperty("led2")]
        public string Led2 { get; set; }
        [JsonProperty("temperatura")]
        public float Temperatura { get; set; }
    }
}

