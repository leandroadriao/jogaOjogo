using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JOJ.APP
{
    class Menu
    {
        public ObservableCollection<TopMenu> TopMenuItems { get; set; }
        public Menu()
        {
            TopMenuItems = new ObservableCollection<TopMenu>();
        }
    }

    class TopMenu
    {
        public string GroupName { get; set; }
        public ObservableCollection<SubMenu> SubMenuItems { get; set; }
        public TopMenu()
        {
            SubMenuItems = new ObservableCollection<SubMenu>();
        }
    }

    class SubMenu
    {
        public string ItemName { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Times : ContentPage
    {
        //private List<Deserialize.Jogador> _times;
        private Deserialize.Times _times = new Deserialize.Times();
        public ObservableCollection<Deserialize.Time> CollectionTimes = new ObservableCollection<Deserialize.Time>();
        private int _qtdeJogador;
        public Times(List<Deserialize.Jogador> times, int qtdeJogador)
        {
            InitializeComponent();
           
            //_times = times;
            //_qtdeJogador = qtdeJogador;


            ////lst.ItemsSource = TiraTime(times, qtdeJogador);
            TiraTime(times, qtdeJogador);
            ////foreach (var obj in timess)
            //{

            //    DisplayAlert("Alert", string.Format("Time:{0}", obj.Key), "OK");
            //    foreach (var values in obj.Value)
            //    {
            //        DisplayAlert("Alert", string.Format("{0}-{1}", values.Nome, values.Posicao), "OK");
            //    }

            //}
            BindingContext = _times;
            NewPartsListView.GroupDisplayBinding = new Binding("Nome");
        }
        public Times()
        {
            InitializeComponent();

        }
        async void TiraTime(List<Deserialize.Jogador> listaJogadores, int qtdeJogadores)
        {
            int limiteqtdeJogadores = 0;
            int qtdeTimes = 0;

            ObservableCollection<Deserialize.Jogador> listatimes = new ObservableCollection<Deserialize.Jogador>();
            var rnd = new Random();

            var result = listaJogadores.OrderBy(item => rnd.Next());

            foreach (var obj in result)
            {
                if (limiteqtdeJogadores == 0)
                {
                    qtdeTimes++;
                    listatimes = new ObservableCollection<Deserialize.Jogador>();
                    _times.ListaTimes.Add(new Deserialize.Time() { Nome= String.Format("Time: {0}", qtdeTimes), Jogadores = listatimes });
                    limiteqtdeJogadores = 0;
                }

                limiteqtdeJogadores++;
                listatimes.Add(obj);

                if (limiteqtdeJogadores == qtdeJogadores)
                {
                    limiteqtdeJogadores = 0;
                }

            }

            int qtdeExe = 1;
            //while (!BalancearTimes(TimesResults) && qtdeExe != 10001)
            //{
            //    TimesResults[1].Add(TimesResults[2][0]);
            //    TimesResults[1].Add(TimesResults[2][1]);
            //    TimesResults[2].RemoveAt(0);
            //    TimesResults[2].RemoveAt(1);

            //    TimesResults[2].Add(TimesResults[1][0]);
            //    TimesResults[2].Add(TimesResults[1][1]);
            //    TimesResults[1].RemoveAt(0);
            //    TimesResults[1].RemoveAt(1);
            //    qtdeExe++;

            //}

            //foreach (var obj in times)
            //{

            //    await DisplayAlert("Alert", string.Format("Time:{0}", obj.Key), "OK");
            //    foreach (var values in obj.Value)
            //    {
            //        await DisplayAlert("Alert", string.Format("{0}-{1}", values.Nome, values.Posicao), "OK");
            //    }

            //}

            // lst.ItemsSource = CollectionTimes;
            //BindingContext = _times;
            //NewPartsListView.ItemsSource = _times.ListaTimes;
        }

        private bool BalancearTimes(Dictionary<int, ObservableCollection<Deserialize.Jogador>> times)
        {
            int count = 0;
            int time1 = 0, time2 = 0;
            foreach (var obj in times)
            {
                if (count == 0)
                {
                    foreach (var values in obj.Value)
                    {
                        if (values.Posicao == 1)
                            time1 = time1 + 1;
                        else
                            time1 = time1 + 2;

                    }
                }
                if (count == 1)
                {
                    foreach (var values in obj.Value)
                    {
                        if (values.Posicao == 1)
                            time2 = time2 + 1;
                        else
                            time2 = time2 + 2;
                    }
                }
                count++;

            }
            if (time1 - time2 == 0)
                return true;
            else
                return false;

        }

        async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            //foreach (var values in _times)
            //{
            //    await DisplayAlert("Alert", string.Format("{0}-{1}", values.Nome, values.Posicao), "OK");
            //}
            //TiraTime(_times, _qtdeJogador);
            //await Navigation.PopAsync();
        }

       

    }
}