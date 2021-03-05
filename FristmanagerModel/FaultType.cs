using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FristManager.Model
{
    public class FaultType
    {
        /// <summary>
        /// 故障类型id
        /// </summary>
        private int _typeId;

        /// <summary>
        /// 故障类型名称
        /// </summary>
        private string _typeName;

        /// <summary>
        /// 故障描述
        /// </summary>
        private string _note;

        public int TypeId
        {
            get { return _typeId; }
            set { _typeId = value; }
        }
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }

    }
}
