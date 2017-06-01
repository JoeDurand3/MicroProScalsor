using MicroProScalsor.ViewModels;
using Xamarin.Forms;

namespace MicroProScalsor.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            this.BindingContext = new AboutViewModel();
            InitializeComponent();
        }
    }
}
