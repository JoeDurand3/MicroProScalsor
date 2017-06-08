using Plugin.BluetoothLE;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroProScalsor.Services
{
    /// <summary>
    /// A bluetooth service that looks for a specific device, based on the MAC address.
    /// </summary>
    class BluetoothService
    {
        public static BluetoothService Instance = new BluetoothService();

        private IDevice _device;

        private ConnectionStatus? _targetDeviceStatus
        {
            get
            {
                if (_device != null)
                {
                    return _device.Status;
                }

                return null;
            }
        }

        public event EventHandler TargetDeviceStatusChanged;

        public string TargetDeviceStatus
        {
            get
            {
                switch (_targetDeviceStatus)
                {
                    case null:
                        return "Not Found";
                    default:
                        return _targetDeviceStatus.ToString();
                }
            }
        }

        /// <summary>
        /// Connects to the device.
        /// </summary>
        public void Connect()
        {

            _device.Connect().Subscribe();
            _device.WhenServiceDiscovered().Subscribe((service) =>
            {
                var uuid = service.Uuid.ToString();

                if (uuid.Equals(value: "6e400001-b5a3-f393-e0a9-e50e24dcca9e"))
                {
                    service.WhenCharacteristicDiscovered().Subscribe((characteristic) =>
                    {
                        var chass = characteristic;

                        if (characteristic.Uuid.Equals("6e400003-b5a3-f393-e0a9-e50e24dcca9e"))
                        {

                            characteristic.Read().Subscribe((data) =>
                            {
                                var res = data;
                            });
                        }
                    });
                }
            });
        }

        /// <summary>
        /// Scans for device.
        /// </summary>
        public void Scan()
        {
            CrossBleAdapter.Current.ScanInterval(new TimeSpan(0, 0, 30));
            CrossBleAdapter.Current.Scan().Subscribe(result =>
            {
                if (_device == null && result.Device.NativeDevice.ToString().Equals(Constants.defaultBluetoothMac))
                {
                    _device = result.Device;
                    _device.WhenStatusChanged().Subscribe(status =>
                    {
                        TargetDeviceStatusChanged.Invoke(this, null);
                    });
                    TargetDeviceStatusChanged.Invoke(this, null);
                }
            });
        }
    }
}
