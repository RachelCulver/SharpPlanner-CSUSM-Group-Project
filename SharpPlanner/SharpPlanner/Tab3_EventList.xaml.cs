using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SharpPlanner
{
    public partial class Tab3_EventList : ContentPage
    {
        public Tab3_EventList()
        {
            InitializeComponent();
            BindingContext = this;

            //TODO: NEEDS ITEM SOURCE below
            EventList.ItemsSource = PlanBase.GetInstance().plans;
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

        //REFRESH LIST
        void EventList_Refreshing(System.Object sender, System.EventArgs e)
        {
            //TODO:We can make it update the list of events incase events are added or deleted




            //last thing to do in function is set refreshing to false...
            EventList.IsRefreshing = false;
        }




        //DELETE
        void MenuItem_Clicked(System.Object sender, System.EventArgs e)
        {
            //TODO:For CONTEXT MENU.. This will need to delete the Event from the list
        }
    }
}
