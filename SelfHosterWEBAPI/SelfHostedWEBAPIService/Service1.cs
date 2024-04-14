using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using OwinSelfhostSample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostedWEBAPIService
{
    public partial class Service1 : ServiceBase
    {

        IDisposable _webApp;
        public Service1()
        {
            InitializeComponent();
        }

        public static string BaseAddress => "http://localhost:9000/";


        protected override void OnStart(string[] args)
        {
            System.Diagnostics.Debugger.Launch();

            // Start OWIN host 
            _webApp = WebApp.Start<Startup>(url: BaseAddress);
            
            // Create HttpClient and make a request to api/values 
            HttpClient client = new HttpClient();

            var pairs = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", "admin"),
                new KeyValuePair<string, string>("password", "123")
            };

            //Console.ReadLine();

            var content = new FormUrlEncodedContent(pairs);

            // Setup the request URL
            var requestUri = $"{BaseAddress}token";

            // Make the request
            var token = client.PostAsync(requestUri, content).Result.Content.ReadAsStringAsync().Result;

            Authoken aToken = JsonConvert.DeserializeObject<Authoken>(token);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", aToken.Token);

            var response = client.GetAsync(BaseAddress + "api/values").Result;
        }

        protected override void OnStop()
        {
            _webApp?.Dispose();
        }
    }

    public class Authoken
    {
        [JsonProperty(PropertyName = "access_token")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int ExipiresIn { get; set; }
    }
}
