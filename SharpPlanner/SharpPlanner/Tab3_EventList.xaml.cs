using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SharpPlanner
{
    public partial class Tab3_EventList : ContentPage
    {
        //private PlanBase Plans = PlanBase.GetInstance();
        PlanBase Plans = PlanBase.GetInstance();

        public Tab3_EventList()
        {
            
            Plans.plans = PlanBase.GetInstance().plans;
            InitializeComponent();
            BindingContext = this;


            //Attach item source

            EventList.ItemsSource = Plans.plans;
            
        }

        public async void ManagePlan(object sender, EventArgs e)
        {
            Plan plan = (Plan)EventList.SelectedItem;
            await Navigation.PushAsync(new ManagePlanPage(plan));
        }

        public void OnAppear(object sender, EventArgs e)
        {
            BindingContext = this;
        }

        
        //DELETE PLAN using context menu
        async void MenuItem_Clicked(System.Object sender, System.EventArgs e)
        {
            //TODO:For CONTEXT MENU.. This will need to delete the Event from the list
            MenuItem mi = (MenuItem)sender;


            //Need help on what to do here, Not sure what PlanBase Object to use??
            //
            bool res = await DisplayAlert("ALERT","Are you sure you want to delete this event?","NO","YES");

            if (res) return; //IF THEY ANSWER NO, RETURN AND DO NOT REMOVE;
            

            Plans.Remove((Plan)mi.CommandParameter);
        }



        //Actually we may not need the below function.. maybe...
        //REFRESH LIST
        void EventList_Refreshing(System.Object sender, System.EventArgs e)
        {
            

            //last thing to do in function is set refreshing to false...
            EventList.IsRefreshing = false;
        }
    }
}
