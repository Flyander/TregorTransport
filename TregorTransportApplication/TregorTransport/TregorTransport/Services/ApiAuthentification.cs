﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TregorTransport.Modeles;
using Xamarin.Essentials;

namespace TregorTransport.Services
{
    class ApiAuthentification
    {
        #region Attributs 
        #endregion
        #region Methodes
        public async Task<bool> GetAuthAsync(string userName, string password)
        {
           
            User modelData = new User(userName, password);
            var jsonstring = JsonConvert.SerializeObject(modelData);
            try
            {
                var client = new HttpClient();

                var jsonContent = new StringContent(jsonstring, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(Constantes.BaseApiAddress + "api/login_check", jsonContent);
                var content = await response.Content.ReadAsStringAsync();
                Tokens token = JsonConvert.DeserializeObject<Tokens>(content);
                this.StockerMotDePasse(token.Token);
                return true;
            }
            catch
            {
                return false;
            }


        }
        public async void StockerMotDePasse(string letoken)
        {
            try
            {
                await SecureStorage.SetAsync("token", letoken);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Erreur lors du stockage du mot de passe, le message d'erreur est :\n" + ex.Message);
                // Possible that device doesn't support secure storage on device.
            }
        }
        #endregion
    }
}