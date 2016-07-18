using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Collections;


namespace OmniUKClass
{
    public class KeySets : IEnumerable, IEnumerator, ICollection
    {
        //Retrieving key values from app.config
        private KeySet[] keysetlist;
        int position = 0;

        public string[] accesskey = ConfigurationManager.AppSettings["accesskeycategories"].ToString().Split(',');
        public string[] secretkey = ConfigurationManager.AppSettings["secretkeycategories"].ToString().Split(',');
        public string[] appnamekey = ConfigurationManager.AppSettings["appnamecategories"].ToString().Split(',');
        public string[] appversionkey = ConfigurationManager.AppSettings["appVersioncategories"].ToString().Split(',');
        public string[] serviceurlkey = ConfigurationManager.AppSettings["serviceurlcategories"].ToString().Split(',');
        public string[] selleridkey = ConfigurationManager.AppSettings["selleridcategories"].ToString().Split(',');
        public string[] mwsauthtokenkey = ConfigurationManager.AppSettings["mwsauthtokencategories"].ToString().Split(',');
        public string[] marketplaceidkey = ConfigurationManager.AppSettings["marketplaceidcategories"].ToString().Split(',');

        public KeySets()
        {
            //storing array of keys individually
            keysetlist = new KeySet[accesskey.Length];
            for (int i = 0; i < accesskey.Length; i++)
            {
                keysetlist[i] = new KeySet(accesskey[i].ToString(), secretkey[i].ToString(), appnamekey[i].ToString(), appversionkey[i].ToString(), serviceurlkey[i].ToString(), selleridkey[i].ToString(), mwsauthtokenkey[i].ToString(), marketplaceidkey[i].ToString());
            }

        }
        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)this;
        }

        //IEnumerator
        public bool MoveNext()
        {
            //Key move to next
            position++;
            return (position < keysetlist.Length);
        }

        //IEnumerable
        public void Reset()
        { position = 0; }

        //IEnumerable
        public object Current
        {
            get { return keysetlist[position]; }
        }
        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsSynchronized
        {
            get { throw new NotImplementedException(); }
        }

        public object SyncRoot
        {
            get { throw new NotImplementedException(); }
        }

    }

}