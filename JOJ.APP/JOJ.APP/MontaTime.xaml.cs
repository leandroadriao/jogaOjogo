using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCLStorage;

namespace JOJ.APP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MontaTime : ContentPage
    {
        HttpClient client = new HttpClient();
        Deserialize.Jogador jogador = new Deserialize.Jogador();

        public MontaTime()
        {
            InitializeComponent();
            //BuscaJogadoresAPI();
            BuscaJogadores();
        }

        private async void BuscaJogadoresAPI()
        {
            try
            {
                string json = await GetCustomerAsync();
                lstNomes.ItemsSource = JsonConvert.DeserializeObject<List<Deserialize.Jogador>>(json);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async void BuscaJogadores()
        {
          lstNomes.ItemsSource = await jogador.ObterTodosJogadores();
        }

        async Task<string> GetCustomerAsync()
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri("http://10.11.85.21:3000/");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Jogador");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else return response.ReasonPhrase;
        }

        async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        void bntMontaTimeButtonClicked(object sender, EventArgs e)
        {
            List<Deserialize.Jogador> lstJogador = new List<Deserialize.Jogador>();
            foreach(Deserialize.Jogador jogador in lstNomes.ItemsSource)
            {
                if (jogador.Selected)
                lstJogador.Add(jogador);

            }
            if (lstJogador.Count == 0)
            {
                DisplayAlert("Alert", "Nenhum Jogador selecionado!", "OK");
                return;
            }
            Navigation.PushAsync(new Times(lstJogador, int.Parse(etyQtdeJogadores.Text)));
            //Navigation.PushAsync(new Times());
            //await Navigation.PopAsync();
        }
    }
}