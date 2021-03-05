using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FristManager.Model
{
    public class PositionType
    {
        private int _posId;

        public int PosId
        {
            get { return _posId; }
            set { _posId = value; }
        }

        private string _posName;

        public string PosName
        {
            get { return _posName; }
            set { _posName = value; }
        }
    }
}
