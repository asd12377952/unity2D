using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.IO;

public class levelManager : MonoBehaviour {

	public string nextLevel;
	public GameObject boss;
	
	void Start () {
		gameObject.SetActive(false);
	}
	//檢查是否碰到玩家，如果碰到標籤為Player的物件時要前進至下一個設定的關卡
	void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
			PlayerPrefs.SetString("savedLevel", nextLevel);
			GameData.exppoint +=15;
			/*PlayerPrefs.SetInt("hp",GameData.hp);
			PlayerPrefs.SetFloat("damage", GameData.damage);
			PlayerPrefs.SetInt("def", GameData.def);
			PlayerPrefs.SetFloat("bulletLife", GameData.bulletLife);
			PlayerPrefs.SetInt("lv", GameData.lv);
			PlayerPrefs.SetInt("exp", GameData.exp);
			PlayerPrefs.SetInt("point", GameData.point);
			PlayerPrefs.SetInt("jumpTwice", GameData.jumpTwice);
			PlayerPrefs.SetInt("twiceshoot", GameData.twiceshoot);
			SceneManager.LoadScene(nextLevel);*/
			Data newData = new Data
        	{
				hp = GameData.hp,
				jumpTwice = GameData.jumpTwice,
				twiceshoot = GameData.twiceshoot,
				damage = GameData.damage,
				bulletLife = GameData.bulletLife,
				def = GameData.def,
				lv = GameData.lv,
				exp = GameData.exp,
				point = GameData.point,
				exppoint = GameData.exppoint,
        	};
			string jsonInfo = JsonUtility.ToJson(newData,true);
        	File.WriteAllText("C:/Users/asd12/My project/Assets/json1", jsonInfo);
        	Debug.Log("寫入完成");
			SceneManager.LoadScene(nextLevel);
		}
	}
}
public class Data{
	public int hp;
    public int jumpTwice;
    public int twiceshoot;
    public float damage ;
    public float bulletLife;
    public int def;
    public int lv;
    public int exp;
    public int point;
	public int exppoint;
}
