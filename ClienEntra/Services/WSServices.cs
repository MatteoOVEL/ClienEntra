using ClienEntra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ClienEntra.Services
{
    public class WSService
    {
        private readonly HttpClient HttpClient;

        public WSService(string url)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri("https://localhost:7144/api/");
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<Chanteur>> GetSerieAsync(string nomControleur)
        {
            try
            {
                return await HttpClient.GetFromJsonAsync<List<Chanteur>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }
        //public async Task<Musique> GetASerieAsync(Musique serie)
        //{
        //    var response = await HttpClient.GetAsync("series/" + serie.Serieid);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var serieFromResponse = await response.Content.ReadAsAsync<Serie>();
        //        return serieFromResponse;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        public async Task<bool> PostSerieAsync(Musique musique)
        {
            var response = await HttpClient.PostAsJsonAsync("Chanteurs", musique);
            var test = response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode;
        }

        //public async Task<bool> PutSerieAsync(Serie serie)
        //{
        //    var response = await HttpClient.PutAsJsonAsync("series/" + serie.Serieid, serie);
        //    return response.IsSuccessStatusCode;
        //}
        //public async Task<bool> DeleteSerieAsync(Serie serie)
        //{
        //    var response = await HttpClient.DeleteAsync("series/" + serie.Serieid);
        //    return response.IsSuccessStatusCode;
        //}








    }
}
