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


            //TODO: NEEDS ITEM SOURCE below
            //EventList.ItemsSource = 
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
