using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SharpPlanner
{
    public partial class App : Application
    {
        static PlanDB database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            //MainPage = new ManagePlanPage(new Plan("Test", "bababab", new DateTime(2020,3,16), Priority.LOW));
            //MainPage = new MainPage();
        }

        // creates new database
        public static PlanDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new PlanDB();
                }
                return Database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
