using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JOJ.APP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        HttpClient client = new HttpClient();

        public WeatherPage()
        {
            InitializeComponent();
            //Set the default binding to a default object for now  
            BindingContext = new Weather();
        }

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            var secondPage = new MontaTime();
            await Navigation.PushAsync(secondPage);
            //if (!String.IsNullOrEmpty(zipCodeEntry.Text))
            //{
            //    Weather weather = await Core.GetWeather(zipCodeEntry.Text);
            //    BindingContext = weather;
            //    getWeatherBtn.Text = "Search Again";
            //}
            try
            {
                string url = "http://10.11.85.21:3000/api/Jogador/";
                var response = await client.GetAsync(url);
                dynamic data = null;
                if (response != null)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject(json);
                }

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}