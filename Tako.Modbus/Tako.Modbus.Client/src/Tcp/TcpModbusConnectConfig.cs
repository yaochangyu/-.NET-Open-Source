using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;

namespace Tako.Modbus.Client
{
    [Serializable]
    public class TcpModbusConnectConfig : INotifyPropertyChanged
    {
        private string _ipAddress = "127.0.0.1";
        private int _port = 502;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public string IpAddress
        {
            get { return _ipAddress; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                IPAddress result;
                if (IPAddress.TryParse(value, out result))
                {
                    _ipAddress = value;
                }
                OnPropertyChanged("IpAddress");
            }
        }

        public int Port
        {
            get { return _port; }
            set
            {
                _port = value;
                OnPropertyChanged("Port");
            }
        }
    }
}