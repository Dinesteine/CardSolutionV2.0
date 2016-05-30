using System;
namespace CardSolutionHost.Entitys
{
    public partial class MachinesEntity : BaseEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public MachinesEntity()
        {
            MachineAlias = string.Empty;
            IP = string.Empty;
            CommPassword = string.Empty;
            FirmwareVersion = string.Empty;
            ProductType = string.Empty;
            DeviceNetmask = string.Empty;
            DeviceGetway = string.Empty;
            sn = string.Empty;
            PhotoStamp = string.Empty;
        }
        public int ID { get; set; }
        public string MachineAlias { get; set; }
        public int ConnectType { get; set; }
        public string IP { get; set; }
        public int SerialPort { get; set; }
        public int Port { get; set; }
        public int Baudrate { get; set; }
        public int MachineNumber { get; set; }
        public bool IsHost { get; set; }
        public bool Enabled { get; set; }
        public string CommPassword { get; set; }
        public short UILanguage { get; set; }
        public short DateFormat { get; set; }
        public short InOutRecordWarn { get; set; }
        public short Idle { get; set; }
        public short Voice { get; set; }
        public short managercount { get; set; }
        public short usercount { get; set; }
        public short fingercount { get; set; }
        public short SecretCount { get; set; }
        public string FirmwareVersion { get; set; }
        public string ProductType { get; set; }
        public short LockControl { get; set; }
        public int Purpose { get; set; }
        public string DeviceNetmask { get; set; }
        public string DeviceGetway { get; set; }
        public string sn { get; set; }
        public string PhotoStamp { get; set; }
    }
}
