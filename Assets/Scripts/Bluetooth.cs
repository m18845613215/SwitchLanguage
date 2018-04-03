using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bluetooth
{
    public List<string> MacAddresses = new List<string>();//List for the Bluetooth Devices 列出蓝牙设备。
    private static Bluetooth Instance_obj;//蓝牙单例对象，使这个类可以访问。
    private AndroidJavaClass _plugin;//AndroidJavaClass对象
    private AndroidJavaObject _activityObject;//AndroidJavaObject Object
    public static Bluetooth Instance()//Constractor
    {
        if (Instance_obj == null)
        {
            Instance_obj = new Bluetooth();
            Instance_obj.PluginStart();
        }
        return Instance_obj;
    }
    private void PluginStart()//开始初始化插件。
    {
	    _plugin = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        _activityObject = _plugin.GetStatic<AndroidJavaObject>("currentActivity");
        _activityObject.Call("StartFun");

    }
    public string Send(string message)//向连接设备发送特定的消息
    {
        return _activityObject.Call<string>("sendMessage", message);
    }
    public string SearchDevice()//搜索设备功能，搜索其他设备。
    {
       MacAddresses.Clear();
       return _activityObject.Call<string>("ScanDevice");
       
    }
    public string GetDeviceConnectedName()//获取设备连接名称函数以检索连接设备的名称。
    {
       return _activityObject.Call<string>("GetDeviceConnectedName");

    }
    public string Discoverable()//确保当前的蓝牙是可发现的。
    {
        return _activityObject.Call<string>("ensureDiscoverable");
    }
    public void Connect(string Address)//连接到另一个设备。
    {
        _activityObject.Call("Connect", Address);
    }
    public string EnableBluetooth()//如果有的话，可以使用蓝牙。
    {
        return _activityObject.Call<string>("BluetoothEnable");
    }
    public string DisableBluetooth()//如果启用了蓝牙，就禁用它。
    {
        return _activityObject.Call<string>("DisableBluetooth");
    }
    public string DeviceName()//获取当前的蓝牙设备名称。
    {
        return _activityObject.Call<string>("DeviceName");
    }
    public bool IsEnabled()//是蓝牙
    {
        return _activityObject.Call<bool>("IsEnabled");
    }
    public bool IsConnected()//当前蓝牙设备连接吗?
    {
        return _activityObject.Call<bool>("IsConnected");
    }
	public void Stop()//停止当前连接
    {
		_activityObject.Call("stopThread");
	}
	public void showMessage(string mes)
	{
		_activityObject.Call("showMessage",mes);
	}
}