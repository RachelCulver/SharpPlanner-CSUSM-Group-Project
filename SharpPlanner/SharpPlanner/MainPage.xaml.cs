using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SharpPlanner
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            Children.Add(new Tab3_EventList());
            Children.Add(new Calendar());
            Children.Add(new CreatePlanPage(this));
        }

    
    }
}
