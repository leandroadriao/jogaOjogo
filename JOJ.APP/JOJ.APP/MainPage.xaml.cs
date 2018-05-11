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
        async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            var secondPage = new MontaTime();
            await Navigation.PushAsync(secondPage);
        }

        async void OnNavigateMontaTime(object sender, EventArgs e)
        {
            var secondPage = new MontaTime();
            await Navigation.PushAsync(secondPage);
        }
    }
}
