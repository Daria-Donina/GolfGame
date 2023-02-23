using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DefaultNamespace.Server;
using UnityEngine;

namespace DefaultNamespace.Progress
{
    public class ProgressServerHandler : IDisposable
    {
        private const string JsonContentMediaType = "application/json";
        private readonly HttpClient _client;
        
        private static string RequestUri => $"profile_id={ProfileID}";
        private static string Uri => ServerConstants.ServerRootUri + "progress/";
        private static string ProfileID => SystemInfo.deviceUniqueIdentifier;

        public ProgressServerHandler()
        {
            _client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            _client.BaseAddress = new Uri(Uri);
        }

        public void SaveProgress(string data)
        {
            var content = new StringContent(data, Encoding.UTF8, JsonContentMediaType);
            var response = _client.PostAsync(RequestUri, content).Result;

            response.EnsureSuccessStatusCode();
        }

        public string LoadProgress()
        {
            var response = _client.GetAsync(RequestUri).Result;
            
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;

            return result;
        }


        public void Dispose()
        {
            _client?.Dispose();
        }
    }
}