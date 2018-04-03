using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 调用蓝牙
/// </summary>
public class CallBluetooth : MonoBehaviour {

    AndroidJavaObject unityActivity;
    AndroidJavaObject bluetoothAdapter;

    string text;
    private void Start() {
        unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
    }

    void OnGUI() {
        if(GUI.Button(new Rect(0, 0, 100, 100), "")) {

        }

    }
}