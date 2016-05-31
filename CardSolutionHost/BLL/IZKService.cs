using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using zkemkeeper;

namespace CardSystem_Service.ZKManage
{
    [ServiceContract(CallbackContract = typeof(I_ZK_Callback), SessionMode = SessionMode.Required, Name = "ZKService")]
    public interface IZKService
    {
        #region 接口
        /// <summary>
        /// 播放
        /// </summary>
        /// <param name="voiceIndex"></param>
        /// <returns></returns>
        [OperationContract]
        bool PlayVoiceByIndex(int voiceIndex);
        /// <summary>
        /// 读取用户信息
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <returns></returns>
        [OperationContract]
        bool ReadAllUserID(int dwMachineNumber);
        /// <summary>
        /// 开门
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="Delay">延时时间</param>
        /// <returns></returns>
        [OperationContract]
        bool ACUnlock(int dwMachineNumber, int Delay);
        /// <summary>
        /// 获取刷卡记录
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="dwEnrollNumber">用户Id</param>
        /// <param name="dwVerifyMode">该考勤记录的验证方式</param>
        /// <param name="dwInOutMode">考勤记录的考勤状态</param>
        /// <param name="TimeStr">接收该考勤记录的考勤时间</param>
        /// <returns></returns>
        [OperationContract]
        bool GetGeneralLogDataStr(int dwMachineNumber, ref int dwEnrollNumber, ref int dwVerifyMode, ref int dwInOutMode, ref string TimeStr);
        /// <summary>
        /// 读取考勤记录到PC 的内部缓冲区
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <returns></returns>
        [OperationContract]
        bool ReadGeneralLogData(int dwMachineNumber);
        /// <summary>
        /// 获取SDK 属性cardnumber 的值，一般在获取到用户信息后即可利用该函数获得相应用户的卡号信息
        /// </summary>
        /// <param name="ACardNumber">卡号</param>
        /// <returns></returns>
        [OperationContract]
        bool GetStrCardNumber(out string ACardNumber);
        /// <summary>
        /// 删除登记数据
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="dwEnrollNumber">用户Id</param>
        /// <param name="dwEMachineNumber">设备编号</param>
        /// <param name="dwBackupNumber">指纹索引</param>
        /// <returns></returns>
        [OperationContract]
        bool DeleteEnrollData(int dwMachineNumber, int dwEnrollNumber, int dwEMachineNumber, int dwBackupNumber);
        /// <summary>
        /// 取得所有用户信息。在该函数执行之前，可用ReadAllUserID 读取到所有用户信息到内存，
        /// GetAllUserInfo 每执行一次，指向用户信息指针移到下一记录，当读完所有用户信息后，函数返回False。
        /// 和GetAllUserID 不同的是本函数能获得更多的信息
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="dwEnrollNumber">用户Id</param>
        /// <param name="Name">用户姓名</param>
        /// <param name="Password">密码</param>
        /// <param name="Privilege">权限</param>
        /// <param name="Enabled">是否启用</param>
        /// <returns></returns>
        [OperationContract]
        bool GetAllUserInfo(int dwMachineNumber, ref int dwEnrollNumber, ref string Name, ref string Password, ref int Privilege, ref bool Enabled);
        /// <summary>
        /// 设置设备信息
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="dwInfo">需获取的信息类型</param>
        /// 1	最大管理员数，总是返回500
        /// 2	机器号
        /// 3	语言
        /// 4	空闲时长(分钟)，即空闲该段时间后机器进入待机或关机
        /// 5	锁控时长，即锁驱动时长
        /// 6	考勤记录报警数，即当考勤记录达到该数量时，机器会报警以提示用户
        /// 7	操作记录报警数，即当操作记录达到该数量时，机器会报警以提示用户
        /// 8	重复记录时间，即同一用户打同一考勤状态的最小时间间隔
        /// 9	232/485 通讯的波特率
        /// 10	奇偶校验，总是返回0
        /// 11	停止位，总是返回0
        /// 12 	日期分隔符，总是返回1
        /// 13 	网络功能是否启用，返回值：1 为启用，0 为禁用
        /// 14 	RS232 是否启用
        /// 15 	RS485 是否启用
        /// 16 	是否有声音功能
        /// 17 	是否进行高速比对
        /// 18 	空闲方式，即空间时间后进入的状态，返回值：87 为关机，88 休眠
        /// 19 	自动关机时间点，默认值为255，即不自动关机
        /// 20 	自动开机时间点，默认值为255，即不自动开机
        /// 21 	自动休眠时间点，默认值为255，即不自动休眠
        /// 22 	自动响铃时间点1，默认值为65535，即不自动响铃
        /// 23 	1:N 比对匹配阀值
        /// 24 	登记时匹配阀值
        /// 25 	1:1 匹配阀值
        /// 26 	验证时是否显示匹配分数
        /// 27 	同时开锁人数
        /// 28 	只验证号码卡
        /// 29 	网络速度
        /// 30 	卡是否必需注册
        /// 31 	机器在临时状态无操作自动返回的等待时间
        /// 32 	机器在输入PIN 号时无操作时自动返回的等待时间
        /// 33 	机器在进入菜单后无操作自动返回的等待时间
        /// 34 	时间格式
        /// 35 	是否必需使用1:1 比对
        /// 36—40 自动响铃时间点2、3、4、5、6 ，默认值都为65535，即不自动响铃
        /// 41—56 自动状态转换时间点1—16 ，默认值都为－1，即不会自动状态转换
        /// 57 	wiegand 失败ID
        /// 58 	wiegand 胁迫ID
        /// 59 	wiegand 区位码
        /// 60 	wiegand 输出的脉冲宽度
        /// 61 	wiegand 输出的的脉冲间隔
        /// 62 	MIFARE 卡存储指纹开始扇区数
        /// 63 	MIFARE 卡存储指纹扇区总数
        /// 64 	MIFARE 卡存储指纹数
        /// 66 	是否显示考勤状态
        /// 67-68 暂无意义
        /// <param name="dwValue">欲设置的由dwInfo 描述的信息的值</param>
        /// <returns></returns>
        [OperationContract]
        bool SetDeviceInfo(int dwMachineNumber, int dwInfo, int dwValue);
        /// <summary>
        /// 设置设备IP
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="IPAddr"></param>
        /// <returns></returns>
        [OperationContract]
        bool SetDeviceIP(int dwMachineNumber, string IPAddr);
        /// <summary>
        /// 批量上传
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <returns></returns>
        [OperationContract]
        bool BatchUpdate(int dwMachineNumber);
        /// <summary>
        /// 开始批量上传
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="UpdateFlag">是否覆盖</param>
        /// <returns></returns>
        [OperationContract]
        bool BeginBatchUpdate(int dwMachineNumber, int UpdateFlag);
        /// <summary>
        /// 同步时间
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <returns></returns>
        [OperationContract]
        bool SetDeviceTime(int dwMachineNumber);
        /// <summary>
        /// 获取设备时间
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="dwYear"></param>
        /// <param name="dwMonth"></param>
        /// <param name="dwDay"></param>
        /// <param name="dwHour"></param>
        /// <param name="dwMinute"></param>
        /// <param name="dwSecond"></param>
        /// <returns></returns>
        [OperationContract]
        bool GetDeviceTime(int dwMachineNumber, ref int dwYear, ref int dwMonth, ref int dwDay, ref int dwHour, ref int dwMinute, ref int dwSecond);
        /// <summary>
        /// 关闭设备
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <returns></returns>
        [OperationContract]
        bool PowerOffDevice(int dwMachineNumber);
        /// <summary>
        /// 重启设备
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <returns></returns>
        [OperationContract]
        bool RestartDevice(int dwMachineNumber);
        /// <summary>
        /// 获取设备信息
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="dwInfo">需获取的信息类型</param>
        /// 1	最大管理员数，总是返回500
        /// 2	机器号
        /// 3	语言
        /// 4	空闲时长(分钟)，即空闲该段时间后机器进入待机或关机
        /// 5	锁控时长，即锁驱动时长
        /// 6	考勤记录报警数，即当考勤记录达到该数量时，机器会报警以提示用户
        /// 7	操作记录报警数，即当操作记录达到该数量时，机器会报警以提示用户
        /// 8	重复记录时间，即同一用户打同一考勤状态的最小时间间隔
        /// 9	232/485 通讯的波特率
        /// 10	奇偶校验，总是返回0
        /// 11	停止位，总是返回0
        /// 12 	日期分隔符，总是返回1
        /// 13 	网络功能是否启用，返回值：1 为启用，0 为禁用
        /// 14 	RS232 是否启用
        /// 15 	RS485 是否启用
        /// 16 	是否有声音功能
        /// 17 	是否进行高速比对
        /// 18 	空闲方式，即空间时间后进入的状态，返回值：87 为关机，88 休眠
        /// 19 	自动关机时间点，默认值为255，即不自动关机
        /// 20 	自动开机时间点，默认值为255，即不自动开机
        /// 21 	自动休眠时间点，默认值为255，即不自动休眠
        /// 22 	自动响铃时间点1，默认值为65535，即不自动响铃
        /// 23 	1:N 比对匹配阀值
        /// 24 	登记时匹配阀值
        /// 25 	1:1 匹配阀值
        /// 26 	验证时是否显示匹配分数
        /// 27 	同时开锁人数
        /// 28 	只验证号码卡
        /// 29 	网络速度
        /// 30 	卡是否必需注册
        /// 31 	机器在临时状态无操作自动返回的等待时间
        /// 32 	机器在输入PIN 号时无操作时自动返回的等待时间
        /// 33 	机器在进入菜单后无操作自动返回的等待时间
        /// 34 	时间格式
        /// 35 	是否必需使用1:1 比对
        /// 36—40 自动响铃时间点2、3、4、5、6 ，默认值都为65535，即不自动响铃
        /// 41—56 自动状态转换时间点1—16 ，默认值都为－1，即不会自动状态转换
        /// 57 	wiegand 失败ID
        /// 58 	wiegand 胁迫ID
        /// 59 	wiegand 区位码
        /// 60 	wiegand 输出的脉冲宽度
        /// 61 	wiegand 输出的的脉冲间隔
        /// 62 	MIFARE 卡存储指纹开始扇区数
        /// 63 	MIFARE 卡存储指纹扇区总数
        /// 64 	MIFARE 卡存储指纹数
        /// 66 	是否显示考勤状态
        /// 67-68 暂无意义
        /// <param name="dwValue">接收由dwInfo 描述的值</param>
        /// <returns></returns>
        [OperationContract]
        bool GetDeviceInfo(int dwMachineNumber, int dwInfo, ref int dwValue);
        /// <summary>
        /// 获取设备IP地址
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="IPAddr">IP地址</param>
        /// <returns></returns>
        [OperationContract]
        bool GetDeviceIP(int dwMachineNumber, ref string IPAddr);
        /// <summary>
        /// 禁用，启用考勤机
        /// </summary>
        /// <param name="dwMachineNumber">考勤机号</param>
        /// <param name="bFlag">启用为true，禁用为false</param>
        /// <returns>是否执行成功</returns>
        [OperationContract]
        bool EnableDevice(int dwMachineNumber, bool bFlag);
        /// <summary>
        /// 连接考勤机
        /// </summary>
        /// <param name="IPAdd">Ip地址</param>
        /// <param name="Port">连接端口</param>
        /// <returns></returns>
        [OperationContract]
        bool Connect_Net(string IPAdd, int Port);
        /// <summary>
        /// 断开连接
        /// </summary>
        [OperationContract]
        void Disconnect();
        /// <summary>
        /// 刷新设备数据
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <returns></returns>
        [OperationContract]
        bool RefreshData(int dwMachineNumber);
        /// <summary>
        /// 设置时间段
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="TZIndex">时间段Id</param>
        /// <param name="TZ">时间段值</param>
        /// <returns></returns>
        [OperationContract]
        bool SetTZInfo(int dwMachineNumber, int TZIndex, string TZ);
        /// <summary>
        /// 设置组对应的时间段
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="GroupIndex">组Id</param>
        /// <param name="TZs">组对应的时间段s</param>
        /// <returns></returns>
        [OperationContract]
        bool SetGroupTZStr(int dwMachineNumber, int GroupIndex, string TZs);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dwMachineNumber"></param>
        /// <param name="Option"></param>
        /// <param name="Value"></param>
        /// <returns></returns>
        [OperationContract]
        bool SetSysOption(int dwMachineNumber, string Option, string Value);
        /// <summary>
        /// 设置开锁组合
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="Grps">组Ids</param>
        /// <returns></returns>
        [OperationContract]
        bool SetUnlockGroups(int dwMachineNumber, string Grps);
        /// <summary>
        /// 设置用户组
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="dwEnrollNumber">用户Id</param>
        /// <param name="UserGrp">用户所在组</param>
        /// <returns></returns>
        [OperationContract]
        bool SetUserGroup(int dwMachineNumber, int dwEnrollNumber, int UserGrp);
        /// <summary>
        /// 设置用户对应的时间段
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="dwEnrollNumber">用户Id</param>
        /// <param name="TZs"><用户对应的时间段s/param>
        /// <returns></returns>
        [OperationContract]
        bool SetUserTZStr(int dwMachineNumber, int dwEnrollNumber, string TZs);
        /// <summary>
        /// 获取用户对应的时间段
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="dwEnrollNumber">用户Id</param>
        /// <param name="TZs"><用户对应的时间段s/param>
        /// <returns></returns>
        [OperationContract]
        bool GetUserTZStr(int dwMachineNumber, int dwEnrollNumber, ref string TZs);
        [OperationContract]
        void GetLastError(ref int dwErrorCode);
        /// <summary>
        /// 清除刷卡记录
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <returns></returns>
        [OperationContract]
        bool ClearGLog(int dwMachineNumber);
        /// <summary>
        /// 清除机器内由DataFlag 指定的记录
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="DataFlag">
        /// 1	考勤记录
        /// 2	指纹模板数据
        /// 3	无
        /// 4	操作记录
        /// 5	用户信息
        /// </param>
        /// <returns></returns>
        [OperationContract]
        bool ClearData(int dwMachineNumber, int DataFlag);
        /// <summary>
        /// 设置卡号
        /// </summary>
        /// <param name="ACardNumber">卡号</param>
        /// 用法：在SetUserInfo之前调用该方法，可给该用户设置卡号
        /// <returns></returns>
        [OperationContract]
        bool SetStrCardNumber(string ACardNumber);
        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="dwEnrollNumber">用户Id</param>
        /// <param name="Name">用户姓名</param>
        /// <param name="Password">密码</param>
        /// <param name="Privilege">权限</param>
        /// <param name="Enabled">是否启用</param>
        /// <returns></returns>
        [OperationContract]
        bool SetUserInfo(int dwMachineNumber, int dwEnrollNumber, string Name, string Password, int Privilege, bool Enabled);
        #endregion
        /// <summary>
        /// 注册事件
        /// </summary>
        /// <param name="dwMachineNumber">设备编号</param>
        /// <param name="EventMask">事件编号</param>
        /// <summary>
        /// 获取最后一个错误代码
        /// </summary>
        /// <param name="dwErrorCode">错误代码</param>
        [OperationContract]
        void RegEvent(int dwMachineNumber, int EventMask);
        [OperationContract]
        void BindEvent();
    }

    public interface I_ZK_Callback
    {
        [OperationContract(IsOneWay = true)]
        void GetCardNo(int CardNumber);
    }
}