using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 语言切换
/// </summary>
public class SwitchLanguage : MonoBehaviour {
    List<string> StrLanguage;
	public void Start(){
		if (!ReadConfigFiles.SwitchLanguageDic.ContainsKey (gameObject.name))	return;
		ReadConfigFiles.SwitchLanguageDic.TryGetValue (gameObject.name, out StrLanguage);
		OutPut ();
	}
	public void OutPut(){
		Debug.Log ("打印");
		foreach (var item in StrLanguage) {
			Debug.Log (item);
		}
	}
}
