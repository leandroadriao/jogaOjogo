using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JOJ.APP
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroJogador : ContentPage
	{
		public CadastroJogador ()
		{
			InitializeComponent ();
            
		}
        async void OnNavigateButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
