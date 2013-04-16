using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Tako.CRC
{
    [Serializable]
    public class CRCStatus : INotifyPropertyChanged
    {
        private byte[] _fullDataArray;
        private uint _crcDecimal;
        private string _crcHexadecimal;
        private byte[] _crcArray;
        private string _fullDataHexadecimal;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public string CrcHexadecimal
        {
            get { return _crcHexadecimal; }
            set
            {
                _crcHexadecimal = value;
                OnPropertyChanged("CrcHexadecimal");
            }
        }

        public uint CrcDecimal
        {
            get { return _crcDecimal; }
            set
            {
                _crcDecimal = value;
                OnPropertyChanged("CrcDecimal");
            }
        }

        public byte[] CrcArray
        {
            get { return _crcArray; }
            set
            {
                _crcArray = value;
                OnPropertyChanged("CrcArray");
            }
        }

        public byte[] FullDataArray
        {
            get { return _fullDataArray; }
            internal set
            {
                _fullDataArray = value;
                OnPropertyChanged("FullDataArray");
            }
        }

        public string FullDataHexadecimal
        {
            get { return _fullDataHexadecimal; }
            set
            {
                _fullDataHexadecimal = value;
                OnPropertyChanged("Hexadecimal");
            }
        }
    }
}