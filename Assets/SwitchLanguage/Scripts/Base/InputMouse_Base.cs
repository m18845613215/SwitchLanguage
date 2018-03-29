using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// UI输入 父类
/// </summary>
public class InputMouse_Base : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler {

    virtual public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("按下");
        GUI_Debug.SetStr("按下");
    }

    virtual public void OnPointerUp(PointerEventData eventData) {
        Debug.Log("抬起");
        GUI_Debug.SetStr("抬起");
    }

    virtual public void OnPointerClick(PointerEventData eventData) {
        Debug.Log("点击");
        GUI_Debug.SetStr("点击");
    }

    virtual public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log("进入");
        GUI_Debug.SetStr("进入");

    }

    virtual public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("退出");
        GUI_Debug.SetStr("退出");
    }

    virtual protected void Start() {

    }

    virtual protected void Update() {

    }
}
