using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;

/// <summary>
/// 读取配置文件
/// </summary>
public class ReadConfigFiles : MonoBehaviour {

	/// <summary>
	/// 字典存储 Key 唯一识别名字 Value 多语言存储
	/// </summary>
	public static Dictionary<string, List<string>> SwitchLanguageDic = new Dictionary<string, List<string>>();

	private string Path;
	/// <summary>
	/// 文件名字.
	/// </summary>
	private string FileName = "Config.ini";

	private string PathFileName;

	private void Awake(){
		Path = Application.streamingAssetsPath;
		if (Path != null) {
			PathFileName = Path + "/" + FileName;			
			Debug.Log (PathFileName);
		}
		if (File.Exists (PathFileName)) {
			Debug.Log ("文件已存在！");
			ReadConfig (SwitchLanguageDic, 1);
		} else {
			Debug.Log ("创建文件");
			FileStream file = new FileStream (PathFileName, FileMode.Create);
		}
	}

	private void Start(){
		
		#if UNITY_ANDROID  
	Debug.Log("这里是安卓设备");  
		#endif  

		#if UNITY_IPHONE  
	Debug.Log("这里是苹果设备");  
		#endif  

		#if UNITY_STANDALONE_WIN  
		//Debug.Log ("我是从Windows的电脑上运行的");  
		#endif  
		//OutPutDic ();



	}

	public void OutPutDic(){
		foreach (var item in SwitchLanguageDic) {
			Debug.Log (item.Key);
			foreach (var val in item.Value) {
				Debug.Log (val);
			}
			//Debug.Log (item.Value);
		}
	}

	/// <summary>
	/// 读取文件
	/// </summary>
	/// <param name="Keys">Keys.</param>
	/// <param name="Value">Value.</param>
	public void ReadConfig(Dictionary<string, List<string>> Keys, int Value){
		if (!File.Exists (PathFileName))	return;
		FileStream file = new FileStream (PathFileName, FileMode.Open);
		StreamReader fileLineStream = new StreamReader (file);
		string strLine = string.Empty;
		bool IsLook = false;

		while ((strLine = fileLineStream.ReadLine ()) != null) {
			if (strLine == string.Empty)	continue;
			strLine.Trim ();
			string key = string.Empty;
			List<string> value = new List<string>();

			if (strLine.Contains ("=")) {
				string[] StrKey = strLine.Split ('=');
				if (StrKey  == null || StrKey .Length < 1)	return;
				key = StrKey [0].Trim();
				string[] strValue = StrKey [1].Split (',');

				for (int i = 0; i < strValue.Length; i++) {
					if (strValue [i].Contains("{") || strValue [i].Contains("}"))		continue;
					value.Add (strValue[i].Trim());
				}
			}
			Keys.Add(key,value);
		}
		Clear (file);
		return;
	}

	/// <summary>
	/// 关闭文件流
	/// </summary>
	/// <param name="file">File.</param>
	public void Clear(FileStream file){
		file.Flush ();
		file.Close ();
	}
}
