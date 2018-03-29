using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUI_Debug : MonoBehaviour {

    public static string Debug;
    void Start() {

    }

    void Update() {

    }

    void OnGUI() {

        GUI.Label(new Rect(10, 10, 100, 1080), Debug); //将字符串显示在屏幕上  
    }
    public static void SetStr(string str) {
        Debug += str + " \n";
    }
}
