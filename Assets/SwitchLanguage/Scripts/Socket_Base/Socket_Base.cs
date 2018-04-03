using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;

public class Socket_Base : MonoBehaviour {

    Socket SocketVisable;
    private void Awake() {
        SocketVisable = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress IP = IPAddress.Parse("127.0.0.1");
        IPEndPoint ipe = new IPEndPoint(IP, 2012);//把ip和端口转化为IPEndPoint实例

        SocketVisable.Connect(ipe);

        byte[] By = new byte[1024];
        Debug.Log(SocketVisable.Receive(By) + "           " + By.ToString());
        SocketVisable.Send(ASCIIEncoding.UTF8.GetBytes("我有个问题"));
    }
}
