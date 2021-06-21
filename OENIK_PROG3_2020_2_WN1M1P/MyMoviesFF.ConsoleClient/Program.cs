// <copyright file="Program.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Program class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        public static void Main()
        {
            string url = @"http://localhost:58708/ActorsApi/";
            Console.WriteLine("WAITING...");
            Console.ReadLine();

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web) { ReferenceHandler = ReferenceHandler.Preserve, WriteIndented = true };
            using (HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync(new Uri(url + "all")).Result;
                var list = JsonSerializer.Deserialize<List<Actor>>(json, jsonOptions);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();

                Dictionary<string, string> postData;
                string response;

                postData = new Dictionary<string, string>();
                postData.Add(nameof(Actor.ActorName), "Tamás");
                postData.Add(nameof(Actor.Country), "Hungary");
                using (FormUrlEncodedContent data = new FormUrlEncodedContent(postData))
                {
                    response = client.PostAsync(new Uri(url + "add"), data).Result.Content.ReadAsStringAsync().Result;
                }

                json = client.GetStringAsync(new Uri(url + "all")).Result;
                Console.WriteLine("ADD: " + response);
                Console.WriteLine("ALL: " + json);
                Console.ReadLine();

                int actorid = JsonSerializer.Deserialize<List<Actor>>(json, jsonOptions).Single(i => i.ActorName == "Tamás").ActorId;
                postData = new Dictionary<string, string>();
                postData.Add(nameof(Actor.ActorId), actorid.ToString(CultureInfo.CurrentCulture));
                postData.Add(nameof(Actor.ActorName), "János");
                postData.Add(nameof(Actor.Country), "Germany");
                postData.Add(nameof(Actor.Age), "34");

                using (FormUrlEncodedContent data = new FormUrlEncodedContent(postData))
                {
                    response = client.PostAsync(new Uri(url + "mod"), data).Result.Content.ReadAsStringAsync().Result;
                }

                Console.WriteLine("MOD: " + response);
                Console.WriteLine("ALL: " + client.GetStringAsync(new Uri(url + "all")).Result);
                Console.ReadLine();

                Console.WriteLine("DEL: " + client.GetStringAsync(new Uri(url + "del/" + actorid)).Result);
                Console.WriteLine("ALL: " + client.GetStringAsync(new Uri(url + "all")).Result);
                Console.ReadLine();
            }
        }
    }
}
