using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BluetoothGUI : MonoBehaviour
{
    public static string Result = "";//显示插件结果
    void OnGUI()
    {
        GUI.enabled = false;
        GUI.TextField(new Rect(0, (Screen.height / 10) * 9, Screen.width, Screen.height / 10), Result);
        GUI.enabled = true;

		if (GUI.Button(new Rect(300, 0, Screen.width / 3, Screen.height / 10), "显示提示框"))
		{
			Bluetooth.Instance().showMessage("显示框测试");

		}
        //Send Button
        if (GUI.Button(new Rect(0, 0, Screen.width / 3, Screen.height / 10), "发送"))
        {
			float x=1.5f;
			Bluetooth.Instance().Send(x.ToString());

            Result = Bluetooth.Instance().Send("Your Message");
        }
        //Search Button
        if (GUI.Button(new Rect(0, (Screen.height / 10), Screen.width / 3, Screen.height / 10), "搜索设备"))
        {
            Result = Bluetooth.Instance().SearchDevice();
        }
        //Discoverable Button
        if (GUI.Button(new Rect(0, (Screen.height / 10) * 2, Screen.width / 3, Screen.height / 10), "发现的设备"))
        {
            Result = Bluetooth.Instance().Discoverable();
        }
        //Enable Bluetooth Button
        if (GUI.Button(new Rect(0, (Screen.height / 10) * 3, Screen.width / 3, Screen.height / 10), "开启蓝牙"))
        {
            Result = Bluetooth.Instance().EnableBluetooth();
        }
        //Disable Bluetooth Button
        if (GUI.Button(new Rect(0, (Screen.height / 10) * 4, Screen.width / 3, Screen.height / 10), "关闭蓝牙"))
        {
            Result = Bluetooth.Instance().DisableBluetooth();
        }
        //Get Device Connected Name Button
        if (GUI.Button(new Rect(0, (Screen.height / 10) * 5, Screen.width / 3, Screen.height / 10), "已连接的设备名"))
        {
            Result = Bluetooth.Instance().GetDeviceConnectedName();
        }
        //Get Current Device Name Button
        if (GUI.Button(new Rect(0, (Screen.height / 10) * 6, Screen.width / 3, Screen.height / 10), "得到设备名称"))
        {
            Result = Bluetooth.Instance().DeviceName();
        }
        //Is Bluetooth Connecte Button
        if (GUI.Button(new Rect(0, (Screen.height / 10) * 7, Screen.width / 3, Screen.height / 10), "是否连接"))
        {
            Result = Bluetooth.Instance().IsConnected().ToString();
        }
        //Is Bluetooth Enabled Button
        if (GUI.Button(new Rect(0, (Screen.height / 10) * 8, Screen.width / 3, Screen.height / 10), "是否启用"))
        {
            Result = Bluetooth.Instance().IsEnabled().ToString();
        }
		//Stop the current connection
		if (GUI.Button(new Rect(0, (Screen.height / 10) * 9, Screen.width / 3, Screen.height / 10), "停止"))
		{
			Bluetooth.Instance().Stop();
		}
        //Devices the Bluetooth found, so you can connect if you want
        for (int i = 0; i < Bluetooth.Instance().MacAddresses.Count; i++)
        {
            if (GUI.Button(new Rect(Screen.width / 2, 0 + (i * (Screen.height / 8)), Screen.width / 3, Screen.height / 8), Bluetooth.Instance().MacAddresses[i]))
            {
                Bluetooth.Instance().Connect(Bluetooth.Instance().MacAddresses[i]);
            }
        }
    }
}