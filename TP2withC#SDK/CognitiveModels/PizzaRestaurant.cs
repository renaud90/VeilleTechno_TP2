﻿// <auto-generated>
// Code generated by LUISGen .\FlightBooking.json -cs Luis.FlightBooking -o .
// Tool github: https://github.com/microsoft/botbuilder-tools
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
using TP2withSDK.Entities;
using System;

namespace Microsoft.BotBuilderSamples
{
    public partial class PizzaRestaurant: IRecognizerConvert
    {
        public string Text;
        public string AlteredText;
        public enum Intent {
            BookFlight,
            Cancel,
            GetWeather,
            None,
            Reserver
        };
        public Dictionary<Intent, IntentScore> Intents;

        public class _Entities
        {
            public string Name;
            public string PhoneNumber;
            public DateTime Time;
            public string Notes;
            public int NumberOfPlaces;
            public DateTimeSpec Date;
            //public object[] Reservation;

            //public class _InstanceReservation
            //{
            //    public InstanceData[] NumberOfPlaces;
            //    public InstanceData[] Date;
            //}

            public class ReservationClass
            {
                public int[] NumberOfPlaces;
                public string[] Date;
                //[JsonProperty("$instance")]
                //public _InstanceReservation _instance;
            }
            public ReservationClass[] Reservation;
            //Instance
            //public class _Instance
            //{
            //    //public InstanceData[] NumberOfPlaces;
            //    public InstanceData[] Reservation;
            //    //public InstanceData[] Date;
            //    //public InstanceData[] To;
            //}
            //[JsonProperty("$instance")]
            //public _Instance _instance;
        }
        public _Entities Entities;

        [JsonExtensionData(ReadData = true, WriteData = true)]
        public IDictionary<string, object> Properties {get; set; }

        public void Convert(dynamic result)
        {
            var app = JsonConvert.DeserializeObject<PizzaRestaurant>(JsonConvert.SerializeObject(result, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
            Text = app.Text;
            AlteredText = app.AlteredText;
            Intents = app.Intents;
            Entities = app.Entities;
            Properties = app.Properties;
        }

        public (Intent intent, double score) TopIntent()
        {
            Intent maxIntent = Intent.None;
            var max = 0.0;
            foreach (var entry in Intents)
            {
                if (entry.Value.Score > max)
                {
                    maxIntent = entry.Key;
                    max = entry.Value.Score.Value;
                }
            }
            return (maxIntent, max);
        }

    }
}
