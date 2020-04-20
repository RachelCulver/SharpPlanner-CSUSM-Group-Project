using System;
using System.IO;
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

            //check if the app has been run for the first time
            string file = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "firstRun.txt");
            if (File.Exists(file))
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                string content = "";
                File.WriteAllText(file, content);
                MainPage = new TutorialPage();
            }
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
