using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepairsClient.Model
{
    public  class Worker
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _id;

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _idCard;

        public string IdCard
        {
            get { return _idCard; }
            set { _idCard = value; }
        }

        
    }
}
