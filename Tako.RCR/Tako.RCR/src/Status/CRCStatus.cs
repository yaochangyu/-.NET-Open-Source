using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Tako.CRC
{
    public class CRCStatus : INotifyPropertyChanged
    {
        private string _checkSum;
        private uint _checkSumValue;
        private byte[] _checkSumArray;
        private byte[] _fullDataArray;
        private string _fullData;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public string CheckSum
        {
            get { return _checkSum; }
            set
            {
                _checkSum = value;
                OnPropertyChanged("CheckSum");
            }
        }

        public uint CheckSumValue
        {
            get { return _checkSumValue; }
            set
            {
                _checkSumValue = value;
                OnPropertyChanged("CheckSumValue");
            }
        }

        public byte[] CheckSumArray
        {
            get { return _checkSumArray; }
            set
            {
                _checkSumArray = value;
                OnPropertyChanged("CheckSumArray");
            }
        }

        public byte[] FullDataArray
        {
            get { return _fullDataArray; }
            set
            {
                _fullDataArray = value;
                OnPropertyChanged("FullDataArray");
            }
        }

        public string FullData
        {
            get { return _fullData; }
            set
            {
                _fullData = value;
                OnPropertyChanged("FullData");
            }
        }
    }
}