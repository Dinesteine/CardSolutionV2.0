using System.Net.Sockets;
using P2P.WellKnown;
using System.Threading;
using System.Net;
using System.IO;
using System;
using System.Data;
using P2P.WellKnown.S2C;
using P2P.WellKnown.C2S;
using CardSolutionHost.Core;

namespace CardSolutionHost.BLL
{
    ///<summary>
    /// Server 的摘要说明。
    ///</summary>
    public class UdpMsgService
    {
        private UdpClient server;
        System.Timers.Timer _timer = new System.Timers.Timer();
        private UserCollection userList = new UserCollection();
        private volatile bool state = false;
        Thread thread;
        public UdpMsgService()
        {
            thread = new Thread(Run);
            thread.IsBackground = true;
            thread.Start();
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Interval = 1000 * 60 * 3;
            _timer.AutoReset = false;
            _timer.Start();
        }
        void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.SendToEveryBody();
            ResetInterval();
        }

        private void ResetInterval()
        {
            try
            {
                object obj = new MessageService().GetLastSendTime();
                if (obj == null)
                {
                    _timer.Interval = 1000 * 60 * 15;
                    return;
                }
                DateTime dt;
                bool flag = DateTime.TryParse(obj.ToString(), out dt);
                if (flag)
                {
                    double nextTimeSpan = (dt - DateTime.Now).TotalMilliseconds;
                    if (nextTimeSpan > 1000 * 60 * 15)
                    {
                        _timer.Interval = 1000 * 60 * 15;
                        return;
                    }
                    else if (nextTimeSpan < 0)
                    {
                        _timer.Interval = 1000 * 60 * 15;
                        return;
                    }
                    else
                    {
                        _timer.Interval = nextTimeSpan;
                        return;
                    }
                }
                else
                {
                    _timer.Interval = 1000 * 60 * 15;
                    return;
                }
            }
            catch
            {
            }
        }
        private void SendToEveryBody()
        {
            try
            {
                byte[] serverBuffer = ToQueryMsg();
                foreach (User user in userList)
                {
                    server.Send(serverBuffer, serverBuffer.Length, user.NetPoint);
                }
            }
            catch
            {
            }
        }

        private byte[] ToQueryMsg()
        {
            byte[] serverBuffer = null;
            try
            {

                DataTable dt = new MessageService().GetMessageToSend().Tables[0]; ;
                NewsCollection newsList = new NewsCollection();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    newsList.Add(new NewsMessage(dt.Rows[i]["Id"].ToString(), dt.Rows[i]["Theme"].ToString()));
                }
                P2P.WellKnown.S2C.GetMsgsResponseMessage msgListReponse = new P2P.WellKnown.S2C.GetMsgsResponseMessage(newsList);
                serverBuffer = FormatterHelper.Serialize(msgListReponse);
            }
            catch
            {
            }
            return serverBuffer;
        }
        public void Start()
        {
            try
            {

                server = new UdpClient(SystemConfig.UdpMsgServicePort);
                state = true;
            }
            catch
            {

            }
        }
        public void Stop()
        {
            try
            {
                state = false;
                server.Close();
            }
            catch
            {
            }
        }
        private void Run()
        {
            while (state)
            {
                IPEndPoint remoteIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] msgBuffer = server.Receive(ref remoteIP);
                Thread thread = new Thread(new ParameterizedThreadStart(Work));
                thread.IsBackground = true;
                thread.Start(new object[] { remoteIP, msgBuffer });
            }
        }
        private void Work(object obj)
        {
            try
            {
                var paras = obj as object[];
                IPEndPoint remoteIP = paras[0] as IPEndPoint;
                byte[] msgBuffer = paras[1] as byte[];
                byte[] buffer = null;
                object msgObj = FormatterHelper.Deserialize(msgBuffer);
                if (msgObj is LoginMessage)
                {
                    LoginMessage lginMsg = (LoginMessage)msgObj;
                    IPEndPoint userEndPoint = new IPEndPoint(remoteIP.Address, remoteIP.Port);
                    User user = new User(lginMsg.UserName, userEndPoint);
                    OnFriendLoginMessage onFriendLoginMessage = new OnFriendLoginMessage(user);
                    buffer = FormatterHelper.Serialize(onFriendLoginMessage);
                    foreach (User item in userList)
                    {
                        server.Send(buffer, buffer.Length, item.NetPoint);
                    }
                    if (!userList.Contain(user))
                        userList.Add(user);
                    // 发送应答消息
                    OnLoginMessage onloginmsg = new OnLoginMessage(userList);
                    buffer = FormatterHelper.Serialize(onloginmsg);
                    server.Send(buffer, buffer.Length, remoteIP);
                }
                else if (msgObj is LogoutMessage)
                {
                    P2P.WellKnown.C2S.LogoutMessage lgoutMsg = (P2P.WellKnown.C2S.LogoutMessage)msgObj;
                    User lgoutUser = userList.Find(lgoutMsg.UserName);
                    if (lgoutUser != null)
                    {
                        userList.Remove(lgoutUser);
                    }
                }
                else if (msgObj is P2P.WellKnown.C2S.DownLoadMessage)
                {
                    //DownLoadMessage downLoadMessage = msgObj as DownLoadMessage;
                    //UdpTranferFile.UdpSendFile udpSendFile = new UdpTranferFile.UdpSendFile(remoteIP.Address.ToString(), downLoadMessage.Port, 2280);
                    //udpSendFile.Start();
                    //UdpTranferFile.SendFileManager sendFileManager = new UdpTranferFile.SendFileManager(downLoadMessage.FileName);
                    //if (udpSendFile.CanSend(sendFileManager))
                    //{
                    //    udpSendFile.SendFile(sendFileManager, null);
                    //}
                    //else
                    //{
                    //    //MessageBox.Show("文件正在发送，不能发送重复的文件。");
                    //}

                }
                else if (msgObj is GetUsersMessage)
                {
                    GetUsersResponseMessage srvResMsg = new GetUsersResponseMessage(userList);
                    buffer = FormatterHelper.Serialize(srvResMsg);
                    foreach (User user in userList)
                    {
                        server.Send(buffer, buffer.Length, user.NetPoint);
                    }
                }
                else if (msgObj is MassMsg)
                {
                    ResetInterval();
                    this.SendToEveryBody();
                }
                else if (msgObj is TranslateMessage)
                {
                    P2P.WellKnown.C2S.TranslateMessage transMsg = (P2P.WellKnown.C2S.TranslateMessage)msgObj;
                    User toUser = userList.Find(transMsg.ToUserName);
                    // 转发Purch Hole请求消息
                    if (toUser == null)
                    {
                        //Console.WriteLine("Remote host {0} cannot be found at index server", transMsg.ToUserName);
                    }
                    else
                    {
                        SomeOneCallYouMessage transMsg2 = new SomeOneCallYouMessage(remoteIP);
                        buffer = FormatterHelper.Serialize(transMsg);
                        server.Send(buffer, buffer.Length, toUser.NetPoint);
                    }
                }
            }
            catch (Exception)
            {
            }

        }
    }
}
