using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FristManager.Model
{
    public class Worker
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

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _photo;

        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }


        private string _PosId;

        public string PosId
        {
            get { return _PosId; }
            set { _PosId = value; }
        }
        private string _posName;

        public string PosName
        {
            get { return _posName; }
            set { _posName = value; }
        }

        private string _typeId;
        private string _typeName;

        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }
        public string TypeId
        {
            get { return _typeId; }
            set { _typeId = value; }
        }

        private string _managerId;

        public string ManagerId
        {
            get { return _managerId; }
            set { _managerId = value; }
        }
        private string _managerName;

        public string ManagerName
        {
            get { return _managerName; }
            set { _managerName = value; }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _brithday;

        public string Brithday
        {
            get { return _brithday; }
            set { _brithday = value; }
        }

        private string _entryTime;

        public string EntryTime
        {
            get { return _entryTime; }
            set { _entryTime = value; }
        }

        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
    }
}
