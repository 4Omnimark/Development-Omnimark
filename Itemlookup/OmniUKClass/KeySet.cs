using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OmniUKClass
{
    public class KeySet
    {

        private string Accesskey;
        private string Secretkey;
        private string Appnamekey;
        private string Appversionkey;
        private string Serviceurlkey;
        private string Selleridkey;
        private string Mwsauthtokenkey;
        private string Marketplaceidkey;

        //Creating constructor for keys
        public KeySet(string accesskey, string secretkey, string appnamekey, string appversionkey, string serviceurlkey, string selleridkey, string mwsauthtokenkey, string marketplaceidkey)
        {
            this.Accesskey = accesskey;
            this.Secretkey = secretkey;
            this.Appnamekey = appnamekey;
            this.Appversionkey = appversionkey;
            this.Serviceurlkey = serviceurlkey;
            this.Selleridkey = selleridkey;
            this.Mwsauthtokenkey = mwsauthtokenkey;
            this.Marketplaceidkey = marketplaceidkey;
        }


        public string accesskey
        {
            get { return Accesskey; }
            set { Accesskey = value; }
        }
        public string secretkey
        {
            get { return Secretkey; }
            set { Secretkey = value; }
        }
        public string appnamekey
        {
            get { return Appnamekey; }
            set { Appnamekey = value; }
        }
        public string appversionkey
        {
            get { return Appversionkey; }
            set { Appversionkey = value; }
        }
        public string serviceurlkey
        {
            get { return Serviceurlkey; }
            set { Serviceurlkey = value; }
        }
        public string selleridkey
        {
            get { return Selleridkey; }
            set { Selleridkey = value; }
        }
        public string mwsauthtokenkey
        {
            get { return Mwsauthtokenkey; }
            set { Mwsauthtokenkey = value; }
        }
        public string marketplaceidkey
        {
            get { return Marketplaceidkey; }
            set { Marketplaceidkey = value; }
        }

    }
}