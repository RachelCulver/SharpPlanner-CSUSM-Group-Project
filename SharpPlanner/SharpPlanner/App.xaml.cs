using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SharpPlanner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            //MainPage = new ManagePlanPage(new Plan("Test", "bababab", new DateTime(2020,3,16), Priority.LOW));
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            PlanBase.GetInstance().OnStart();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
