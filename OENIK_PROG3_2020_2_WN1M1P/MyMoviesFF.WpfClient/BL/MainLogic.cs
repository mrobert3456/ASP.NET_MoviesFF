// <copyright file="MainLogic.cs" company="WN1M1P">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MyMoviesFF.WpfClient.BL
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight.Messaging;
    using MyMoviesFF.WpfClient.Data;
    using MyMoviesFF.WpfClient.VM;

    /// <summary>
    /// Implements IMainLogic interface.
    /// </summary>
    public class MainLogic : IMainLogic, IDisposable
    {
        private string url = @"http://localhost:58708/ActorsApi/";
        private HttpClient client = new HttpClient();
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web) { ReferenceHandler = ReferenceHandler.Preserve, WriteIndented = true };

        /// <inheritdoc/>
        public void ApiDelActor(ActorVM actor)
        {
            bool success = false;
            if (actor != null)
            {
                string json = this.client.GetStringAsync(new Uri(this.url + "del/" + actor.ActorId.ToString(CultureInfo.CurrentCulture))).Result;
                JsonDocument doc = JsonDocument.Parse(json);
                success = doc.RootElement.EnumerateObject().Last().Value.GetRawText() == "true";
            }

            this.SendMessage(success);
        }

        /// <inheritdoc/>
        public IList<ActorVM> ApiGetActors()
        {
            string json = this.client.GetStringAsync(new Uri(this.url + "all")).Result;
            var apilist = JsonSerializer.Deserialize<List<ActorFromApi>>(json, this.jsonOptions);
            var list = apilist.Select(i => ActorVM.ConvertFromApi(i)).ToList();
            return list;
        }

        /// <inheritdoc/>
        public void EditActor(ActorVM actor, Func<ActorVM, bool> editor)
        {
            ActorVM clone = new ActorVM();
            if (actor != null)
            {
                clone.CopyFrom(actor);
            }

            bool? success = editor?.Invoke(clone);
            if (success == true)
            {
                if (actor != null)
                {
                    success = this.ApiEditActor(clone, true);
                }
                else
                {
                    success = this.ApiEditActor(clone, false);
                }
            }

            this.SendMessage(success == true);
        }

        /// <inheritdoc/>
        public void SendMessage(bool success)
        {
            string msg = success ? "Operation completed successfully" : "Operation failed";
            Messenger.Default.Send(msg, "ActorResult");
        }

        /// <inheritdoc/>
        public bool ApiEditActor(ActorVM actor, bool isEditing)
        {
            if (actor == null)
            {
                return false;
            }

            string myUrl = isEditing ? this.url + "mod" : this.url + "add";

            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing)
            {
                postData.Add("id", actor.ActorId.ToString(CultureInfo.CurrentCulture));
            }

            postData.Add("ActorId", actor.ActorId.ToString(CultureInfo.CurrentCulture));
            postData.Add("ActorName", actor.ActorName);
            postData.Add("Gender", actor.Gender.ToString());
            postData.Add("Age", actor.Age.ToString(CultureInfo.CurrentCulture));
            postData.Add("Country", actor.Country);

            string json = string.Empty;
            using (FormUrlEncodedContent uri = new FormUrlEncodedContent(postData))
            {
                json = this.client.PostAsync(new Uri(myUrl), uri).
                   Result.Content.ReadAsStringAsync().Result;
            }

            JsonDocument doc = JsonDocument.Parse(json);
            return doc.RootElement.EnumerateObject().Last().Value.GetRawText() == "true";
        }

        /// <summary>
        /// Disposes Httpclient.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose Httpclient.
        /// </summary>
        /// <param name="disposing">Bool indicating whether disposal is happening or not.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.client.Dispose();
            }
        }
    }
}
