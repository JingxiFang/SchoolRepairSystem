using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FristManager.Model
{
    public class FaultInfo
    {
       /// <summary>
       /// 故障id
       /// </summary>
        private int _faultId;
        /// <summary>
        /// 故障物品
        /// </summary>
        private string _faultPro;
        /// <summary>
        /// 故障类型id
        /// </summary>
        private int _typeId;
        /// <summary>
        /// 保修提交时间
        /// </summary>
        private DateTime _subTime;
        /// <summary>
        /// 故障地点
        /// </summary>
        private string _site;
        /// <summary>
        /// 故障描述
        /// </summary>
        private string _desCribe;
        /// <summary>
        /// 图片保存位置
        /// </summary>
        private string _photoPath;
        /// <summary>
        /// 声音保存位置
        /// </summary>
        private string _voicePath;
        /// <summary>
        /// 提交人id
        /// </summary>
        private string _subPeoId;
        /// <summary>
        /// 维修主管id
        /// </summary>
        private string _managerid;
        /// <summary>
        /// 维修主管姓名
        /// </summary>
        private string _managerName;
        /// <summary>
        /// 维修主管电话号码
        /// </summary>
        private string _managerPhoneNum;
        /// <summary>
        /// 维修工id
        /// </summary>
        private string _workerId;
        /// <summary>
        /// 维修工姓名
        /// </summary>
        private string _workerName;
        /// <summary>
        /// 维修工电话
        /// </summary>
        private string _workerPhoneNum;
        /// <summary>
        /// 评价
        /// </summary>
        private string _evaluate;
        /// <summary>
        /// 评价星级
        /// </summary>
        private int _evaluateStar;
        /// <summary>
        /// 故障原因
        /// </summary>
        private string _faultReason;
        /// <summary>
        /// 维修单最新状态
        /// </summary>
        private string _state;
        /// <summary>
        /// 维修单的最新的时间
        /// </summary>
        private DateTime _stateTime;



        public DateTime StateTime
        {
            get { return _stateTime; }
            set { _stateTime = value; }
        }
        public string WorkerPhoneNum
        {
            get { return _workerPhoneNum; }
            set { _workerPhoneNum = value; }
        }
        public string ManagerPhoneNum
        {
            get { return _managerPhoneNum; }
            set { _managerPhoneNum = value; }
        }
        public string ManagerName
        {
            get { return _managerName; }
            set { _managerName = value; }
        }
        public string WorkerName
        {
            get { return _workerName; }
            set { _workerName = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string FaultReason
        {
            get { return _faultReason; }
            set { _faultReason = value; }
        }
        public string FaultPro
        {
            get { return _faultPro; }
            set { _faultPro = value; }
        }
        public int EvaluateStar
        {
            get { return _evaluateStar; }
            set { _evaluateStar = value; }
        }
        public string Evaluate
        {
            get { return _evaluate; }
            set { _evaluate = value; }
        }
        public string WorkerId
        {
            get { return _workerId; }
            set { _workerId = value; }
        }
        public string SubPeoId
        {
            get { return _subPeoId; }
            set { _subPeoId = value; }
        }
        public string VoicePath
        {
            get { return _voicePath; }
            set { _voicePath = value; }
        }
        public string PhotoPath
        {
            get { return _photoPath; }
            set { _photoPath = value; }
        }
        public string DesCribe
        {
            get { return _desCribe; }
            set { _desCribe = value; }
        }
        public String Site
        {
            get { return _site; }
            set { _site = value; }
        }
        public DateTime SubTime
        {
            get { return _subTime; }
            set { _subTime = value; }
        }
        public int TypeId
        {
            get { return _typeId; }
            set { _typeId = value; }
        }
        public int FaultId
        {
            get { return _faultId; }
            set { _faultId = value; }
        }

    }
}


