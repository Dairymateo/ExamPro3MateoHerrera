using AVFoundation;
using ExamPro3MateoHerrera.Modelos;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ExamPro3MateoHerrera.Repositorios
{
    public class CountryRepositorio
    {
        public string _dbPath;
        private SQLiteConnection conn;
        private void Init()
        {
            if (conn != null)
                return;


            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<CountryRepositorio>();





        }

        public void GuardarCountry



        public CountryRepositorio (string dbPath) 
        {
            _dbPath = dbPath;
        }

        public async Task <Country> DevuelveCOuntryAsync() 
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://restcountries.com/v3.1/all");
            string response_json = await response.Result.Content.ReadAsStringAsync();

            Country country = JsonConvert.DeserializeObject<Country>(response_json);

            return country;
        }


        
    }
}
