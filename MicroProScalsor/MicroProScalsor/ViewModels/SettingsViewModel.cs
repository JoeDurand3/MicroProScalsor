using MicroProScalsor.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin;
using Xamarin.Forms;

namespace MicroProScalsor.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
        private BluetoothService _bluetoothService = BluetoothService.Instance;
        private Command _connectCommand;

        public string ConnectionStatusString
        {
            get
            {
                return _bluetoothService.TargetDeviceStatus;
            }
        }

        public Color ConnectionStatusColor
        {
            get
            {
                switch (_bluetoothService.TargetDeviceStatus)
                {
                    case "Not Found":
                        return Color.Red;
                    case "Disconnected":
                        return Color.Yellow;
                    case "Connected":
                        return Color.Green;
                    default:
                        return Color.Black;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [connection possible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [connection possible]; otherwise, <c>false</c>.
        /// </value>
        public bool ConnectionPossible
        {
            get
            {
                return _bluetoothService.TargetDeviceStatus.Equals("Disconnected");
            }
        }

        /// <summary>
        /// Gets the connect command.
        /// </summary>
        /// <value>
        /// The connect command.
        /// </value>
        public Command ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new Command(() => {
                    _bluetoothService.Connect();
                }));
            }
        }

        public SettingsViewModel()
        {
            _bluetoothService.Scan();
            _bluetoothService.TargetDeviceStatusChanged += OnTargetDeviceStatusChanged;
        }


        private void OnTargetDeviceStatusChanged(object sender, EventArgs e)
        {
            RaisePropertyChangedEvent("ConnectionStatusString");
            RaisePropertyChangedEvent("ConnectionStatusColor");
            RaisePropertyChangedEvent("ConnectionPossible");
        }
    }
}
