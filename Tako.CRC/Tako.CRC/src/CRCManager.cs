using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tako.CRC;

namespace Tako.CRC
{
    public class CRCManager
    {
        private EnumOriginalDataFormat _dataFormat = EnumOriginalDataFormat.HEX;

        //property
        private AbsCRCProvider Provider { get; set; }

        public EnumOriginalDataFormat DataFormat
        {
            get { return _dataFormat; }
            set { _dataFormat = value; }
        }

        public AbsCRCProvider CreateCRCProvider(EnumCRCProvider Provider)
        {
            this.Provider = null;
            switch (Provider)
            {
                case EnumCRCProvider.CRC16:
                    this.Provider = new CRC16();
                    break;

                case EnumCRCProvider.CRC32:
                    this.Provider = new CRC32();
                    break;

                case EnumCRCProvider.CRC8:
                    this.Provider = new CRC8();
                    break;

                case EnumCRCProvider.CRC8CCITT:
                    this.Provider = new CRC8(0x07);
                    break;

                case EnumCRCProvider.CRC8DALLASMAXIM:
                    this.Provider = new CRC8(0x31);
                    break;

                case EnumCRCProvider.CRC8SAEJ1850:
                    this.Provider = new CRC8(0x1D);
                    break;

                case EnumCRCProvider.CRC8WCDMA:
                    this.Provider = new CRC8(0x9b);
                    break;

                case EnumCRCProvider.CRC16Modbus:
                    this.Provider = new CRC16Modbus();
                    break;

                case EnumCRCProvider.CRC16CCITT_0x0000:
                    this.Provider = new CRC16CCITT(0x0000);
                    break;

                case EnumCRCProvider.CRC16CCITT_0xFFFF:
                    this.Provider = new CRC16CCITT(0xFFFF);
                    break;

                case EnumCRCProvider.CRC16CCITT_0x1D0F:
                    this.Provider = new CRC16CCITT(0x1D0F);
                    break;

                case EnumCRCProvider.CRC16Kermit:
                    this.Provider = new CRC16Kermit();
                    break;
            }
            this.Provider.DataFormat = this.DataFormat;
            return this.Provider;
        }
    }
}