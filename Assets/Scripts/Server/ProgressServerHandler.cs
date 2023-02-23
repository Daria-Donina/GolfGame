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
    public class ProgressServerHandler
    {
        private string Uri => ServerConstants.ServerRootUri + "progress/";
        private string ProfileID => SystemInfo.deviceUniqueIdentifier;

        public void SaveProgress(string data)
        {
            Debug.Log("Making API post call...");
            using var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            
            client.BaseAddress = new Uri(Uri);
            Debug.Log($"Profile_id {ProfileID}");
            var requestUri = $"profile_id={ProfileID}";
            
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = client.PostAsync(requestUri, content).Result;

            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;
            Debug.Log("Result: " + result);
        }

        public string LoadProgress()
        {
            Debug.Log("Making API get call...");
            using var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate });
            
            client.BaseAddress = new Uri(Uri);
            var requestUri = $"profile_id={ProfileID}";
            var response = client.GetAsync(requestUri).Result;

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Debug.Log($"Result: {response.StatusCode}");
                return null;
            }
            
            response.EnsureSuccessStatusCode();
            var result = response.Content.ReadAsStringAsync().Result;
            Debug.Log("Result: " + result);

            return result;
        }
    }
}