using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Models.CoinMarketPortfolio;
using Newtonsoft.Json;


namespace Portfolio_GasparG.ServicesCoin
{
    public class CoinList
    {
        //Obtenemos los precios de las monedas
        public async Task<List<Coins>> GetCoinPrices()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://cryfolio.azurewebsites.net/api/coins").ConfigureAwait(false);
            client.Dispose();

            var coins = JsonConvert.DeserializeObject<List<Coins>>(response.ToString());
            var coinsFormated = new List<Coins>();
            string strtemp;

            //Se mejora el formato del precio de las monedas
            foreach (var coin in coins)
            {            
                if (coin.price < 1)
                {
                    coin.price = (double)Math.Round(Convert.ToDecimal(coin.price), 4);
                }
                if (coin.price > 1 && coin.price < 1000)
                {
                    coin.price = (double)Math.Round(Convert.ToDecimal(coin.price), 2);
                }
                if (coin.price > 1000)
                {
                    coin.price = (double)Math.Round(Convert.ToDecimal(coin.price), 0);
                }

                //cambio los guiones del nombre de la moneda a guion bajo
                strtemp = coin.name.Replace("-", "_"); 
                coin.imagelocation = strtemp + ".png";

               
                /// Se cambia el color segun si es pos, neg           
                if (coin.PercentChange7day > 0)
                {
                    coin.PercentChange7dayColor = "LightGreen";
                }
                else
                {
                    coin.PercentChange7dayColor = "Red";
                }

                if (coin.PercentChange24hr > 0)
                {
                    coin.PercentChange24hrColor = "LightGreen";
                }
                else
                {
                    coin.PercentChange24hrColor = "Red";
                }

                coin.PercentChange7day = Math.Round(Convert.ToDecimal(coin.PercentChange7day), 2);
                coin.PercentChange24hr = Math.Round(Convert.ToDecimal(coin.PercentChange24hr), 2);
                coin.PercentChange1hr = Math.Round(Convert.ToDecimal(coin.PercentChange1hr), 2);

                coinsFormated.Add(coin);
            }
            return coinsFormated;
        }
    }
}
