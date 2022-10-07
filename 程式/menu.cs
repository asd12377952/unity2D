using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;


public class menu : MonoBehaviour {

	public Button start;
	public Button _continue;
	private bool canContinue = true;
	private Data MyData;
	private string LoadData;
	private string str = System.Environment.CurrentDirectory;
	private string path;
	
	void Start () {
		Time.timeScale = 1;
		string checkLevelName = PlayerPrefs.GetString("savedLevel");
		if(checkLevelName == null || checkLevelName == ""){
			canContinue = false;
		}
		start.onClick.AddListener(() => onStart());
		_continue.onClick.AddListener(() => oncontinue());
		path = str + @"\json1";
	}
	//按鈕內sendMessageUp輸入startGame後按下按鈕會到Level1
	void  onStart() {
		GameData.hp = 250;
		GameData.jumpTwice = 0;
		GameData.twiceshoot = 0;
		GameData.damage = 1.0f;
		GameData.bulletLife = 0.3f;
		GameData.def = 0;
		GameData.lv = 1;
		GameData.exp = 0;
		GameData.point = 1;
		GameData.exppoint = 15;
		GameData.bosslevel = false;
		GameData.score = 100;
		PlayerPrefs.DeleteAll();
		SceneManager.LoadScene("level1");
	}

	//按鈕內sendMessageUp輸入continueGame後按下按鈕會到儲存的關卡
	void oncontinue () {
		if(canContinue){
			string levelName = PlayerPrefs.GetString("savedLevel");
			
			/*StreamReader file = new StreamReader("C:/Player1.txt");
			LoadData =file.ReadToEnd();
			file.Close();*/

			LoadData = File.ReadAllText(path);
			MyData = JsonUtility.FromJson<Data>(LoadData);
			GameData.hp = MyData.hp;
			GameData.jumpTwice = MyData.jumpTwice;
			GameData.twiceshoot = MyData.twiceshoot;
			GameData.damage = Convert.ToSingle(Math.Round(MyData.damage, 1));
			GameData.bulletLife = Convert.ToSingle(Math.Round(MyData.bulletLife, 1));
			GameData.def = MyData.def;
			GameData.lv = MyData.lv;
			GameData.exp = MyData.exp;
			GameData.point = MyData.point;
			GameData.exppoint = MyData.exppoint;
			GameData.bosslevel = MyData.bosslevel;
			GameData.score = MyData.score;
			SceneManager.LoadScene(levelName);


			Debug.Log("讀取完成");
			/*string levelName = PlayerPrefs.GetString("savedLevel");
			SceneManager.LoadScene(levelName);
			GameData.hp = PlayerPrefs.GetInt("hp");
			GameData.damage = PlayerPrefs.GetFloat("damage");
			GameData.def = PlayerPrefs.GetInt("def");
			GameData.bulletLife = PlayerPrefs.GetFloat("bulletLife");
			GameData.lv = PlayerPrefs.GetInt("lv");
			GameData.exp = PlayerPrefs.GetInt("exp");
			GameData.point = PlayerPrefs.GetInt("point");
			GameData.jumpTwice = PlayerPrefs.GetInt("jumpTwice");
			GameData.twiceshoot = PlayerPrefs.GetInt("twiceshoot");*/
		}
	}
}
