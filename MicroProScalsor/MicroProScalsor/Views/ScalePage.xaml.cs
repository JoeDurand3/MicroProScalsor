using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MicroProScalsor.ViewModels;

namespace MicroProScalsor.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScalePage : ContentPage
    {
        public ScalePage()
        {
            this.BindingContext = new ScaleViewModel();
            InitializeComponent();
        }
    }
}
