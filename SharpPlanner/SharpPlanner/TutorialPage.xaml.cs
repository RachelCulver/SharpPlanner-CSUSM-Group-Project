using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SharpPlanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialPage : ContentPage
    {
        public ObservableCollection<TutorialObject> tutorialObjects;
        public TutorialPage()
        {
            tutorialObjects = new ObservableCollection<TutorialObject>();
            tutorialObjects.Add(new TutorialObject("You can see your events here. You can also sort them by date or priority.\nIn order to delete an event, hold it.", "list.png"));
            tutorialObjects.Add(new TutorialObject("You can also click on an event to see more details and edit it.", "manage.png"));
            tutorialObjects.Add(new TutorialObject("If you want to see your event in a calendar, there it is!", "calendar.png"));
            tutorialObjects.Add(new TutorialObject("Weather information? We got you covered!", "weather.png"));
            tutorialObjects.Add(new TutorialObject("Here you can create your own event. It's simple!", "create.png"));
            InitializeComponent();

            CarouselItems.ItemsSource = tutorialObjects;
            
        }

        public void OnCarouselChanged(object sender, CurrentItemChangedEventArgs e)
        {
            if (e.CurrentItem == tutorialObjects[tutorialObjects.Count - 1])
            {
                BtnLeave.Text = "I am ready!";
                BtnLeave.BackgroundColor = Color.Blue;
                BtnLeave.TextColor = Color.White;
            }
            else
            {
                BtnLeave.Text = "Skip";
                BtnLeave.BackgroundColor = Color.Transparent;
                BtnLeave.TextColor = Color.Gray;
            }
        }

        public void GoToMain(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MainPage());
        }
    }
}