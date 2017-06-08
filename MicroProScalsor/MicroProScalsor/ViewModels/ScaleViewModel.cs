using MicroProScalsor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace MicroProScalsor.ViewModels
{
    class ScaleViewModel : BaseViewModel
    {
        private bool _piece1Status = false;
        private bool _piece2Status = false;
        private bool _piece3Status = false;
        private bool _piece4Status = false;

        public string ShoePiece1StatusImage
        {
            get
            {
                return _piece1Status ? "shoe1pressed" : "shoe1notpressed";
            }
        }

        public string ShoePiece2StatusImage
        {
            get
            {
                return _piece2Status ? "shoe2pressed" : "shoe2notpressed";
            }
        }

        public string ShoePiece3StatusImage
        {
            get
            {
                return _piece3Status ? "shoe3pressed" : "shoe3notpressed";
            }
        }

        public string ShoePiece4StatusImage
        {
            get
            {
                return _piece4Status ? "shoe4pressed" : "shoe4notpressed";
            }
        }
    }
}
