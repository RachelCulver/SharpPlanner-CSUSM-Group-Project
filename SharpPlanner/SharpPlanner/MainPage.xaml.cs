using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharpPlanner
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async void CreateEvent(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreatePlanPage());
        }
    }
}
