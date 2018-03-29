using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 调用蓝牙
/// </summary>
public class CallBluetooth : MonoBehaviour {

    //AndroidJavaObject unityActivity;
    //AndroidJavaObject bluetoothAdapter;

    //string text;
    //private void Start() {
    //    unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
    //    AndroidJavaObject javaString = new AndroidJavaObject("java.lang.String", text);

    //    var bluetooth = new AndroidJavaClass("android.bluetooth.BluetoothAdapter");//获得Android BluetoothAdapter类  

    //    bluetoothAdapter = bluetooth.CallStatic<AndroidJavaObject>("getDefaultAdapter");//获取本地蓝牙设备也就是手机的蓝牙  

    //    //判断系统蓝牙是否打开    
    //    if (!bluetoothAdapter.Call<bool>("isEnabled")) {
    //        var isOpen = bluetoothAdapter.Call<bool>("enable");  //打开蓝牙，需要BLUETOOTH_ADMIN权限    
    //    }
    //}
}