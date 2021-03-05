using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepairsClient.Model
{
    public class Reproter
    {
        /// <summary>
        /// 姓名
        /// </summary>
        private string _name;
        /// <summary>
        /// 手机号码
        /// </summary>
        private string _phoneNum;
        /// <summary>
        /// id
        /// </summary>
        private string _id;
        /// <summary>
        /// 身份证号码
        /// </summary>
        private string _idCard;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string PhoneNum
        {
            get { return _phoneNum; }
            set { _phoneNum = value; }
        }
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string IdCard
        {
            get { return _idCard; }
            set { _idCard = value; }
        }

    }
}
