
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JOJ.APP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
      
        }
        async void OnValidationButtonClicked(object sender, EventArgs e)
        {

            Deserialize.Jogador jogador = new Deserialize.Jogador();
            
            //await file.WriteAllTextAsync("01#Jogador01#1#1;02#Jogador02#1#1;03#Jogador03#1#1;04#Jogador04#1#1;05#Jogador05#1#1;06#Jogador06#1#1;07#Jogador07#2#1;08#Jogador08#2#1;09#Jogador09#2#1;10#Jogador10#2#1;11#Jogador11#2#1;12#Jogador12#2#1;13#Jogador13#2#1");
            //DisplayAlert("Alert", jogador.ObterTodosJogadores(), "OK");

            //Verificar se existe 
            //if (PCLHelper.IsFileExistAsync("gamer.txt", folder).Result)
            //{
            //    DisplayAlert("Alert", "Existe", "OK");
            //}
            //else
            //{

            //    DisplayAlert("Alert", "Não Existe", "OK");
            //}

        }
        async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            var secondPage = new CadastroJogador();
            await Navigation.PushAsync(secondPage);
        }

        async void OnNavigateMontaTime(object sender, EventArgs e)
        {
            var secondPage = new MontaTime();
            await Navigation.PushAsync(secondPage);
        }

    }
}
