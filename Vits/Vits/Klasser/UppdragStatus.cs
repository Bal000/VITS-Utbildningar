using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vits
{
    public class UppdragStatus
    {
        private ServiceReference1.CompositeMission _mission;
        private ServiceReference1.CompositeTravelOrder _travelOrder;
        //private bool _sent;

        public ServiceReference1.CompositeMission Mission
        {
            get { return _mission; }
            set { _mission = value; }
        }

        public ServiceReference1.CompositeTravelOrder TravelOrder
        {
            get { return _travelOrder; }
            set { _travelOrder = value; }
        }

        //public bool Sent
        //{
        //    get { return _sent; }
        //    set { _sent = value; }
        //}

        public UppdragStatus()
        {
            _mission = new ServiceReference1.CompositeMission();
            _travelOrder = new ServiceReference1.CompositeTravelOrder();
            //_sent = false;
        }

        
        
    }
}