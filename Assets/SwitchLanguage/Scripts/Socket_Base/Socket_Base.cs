using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System;

public class Socket_Base : MonoBehaviour {

    Socket SocketVisable;
    IPEndPoint Ipe;
    byte[] Reception = new byte[1024];
    private void Awake() {
        SocketVisable = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPAddress IP = IPAddress.Parse("127.0.0.1");
        Ipe = new IPEndPoint(IP, 2012);//把ip和端口转化为IPEndPoint实例

    }

    private void Start() {
        SocketVisable.Connect(Ipe);

        byte[] By = new byte[1024];
        //SocketVisable.BeginAccept(new System.AsyncCallback(this.ConnEnd), null);
        Debug.Log(SocketVisable.BeginReceive(Reception, 0, Reception.Length, SocketFlags.None, new AsyncCallback(this.ReceiveText), SocketVisable) + "           " + By.ToString());
        SocketVisable.Send(ASCIIEncoding.UTF8.GetBytes("UNITY_init 4545455"));
    }

    void OnGUI() {
        if (GUI.Button(new Rect(0, 0, 100, 100), "发送")) {
            Debug.Log("发送字节为       "+SocketVisable.Send(Encoding.UTF8.GetBytes("UNITY_init 4545455")));
        }
    }

    //private void ConnEnd(IAsyncResult ar) {

    //}
    private void ReceiveText(IAsyncResult ar) {
        //获取当前正在工作的Socket对象
        Socket worker = ar.AsyncState as Socket;
        int ByteRead = 0;
        //接收完毕消息后的字节数
        ByteRead = worker.EndReceive(ar);
        string Content = Encoding.Default.GetString(Reception);
        worker.BeginReceive(Reception, 0, Reception.Length, SocketFlags.None, new System.AsyncCallback(ReceiveText), worker);
    }
}
