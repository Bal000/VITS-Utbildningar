using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vits.Klasser
{
    public class Avvikelse
    {
        private DateTime _startDatum;
        private DateTime _stoppDatum;

        public Avvikelse(DateTime inStartDatum, DateTime inStoppDatum)
        {
            _startDatum = inStartDatum;
            _stoppDatum = inStoppDatum;
        }
        
        public DateTime StartDatum 
        {
            get { return _startDatum; }
            set { _startDatum = value; }
        }
        public DateTime StoppDatum
        {
            get { return _stoppDatum; }
            set { _stoppDatum = value; }
        }

    }
}