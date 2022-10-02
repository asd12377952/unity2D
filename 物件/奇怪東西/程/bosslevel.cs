using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class bosslevel : MonoBehaviour
{
    private GameObject target;
    private string str = System.Environment.CurrentDirectory;
	private string path;
    private bool go=false;

    // Start is called before the first frame update
    void Start()
    {
        path = str + @"\json1";
        target = GameObject.Find("player");
        if(GameData.bosslevel){
            gameObject.transform.localPosition = new Vector3(2.1f, 0, 0);
            target.transform.position = new Vector3(271, 61, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(go && transform.localPosition.y<=2.3f){
            gameObject.transform.position += new Vector3(0, 0.1f, 0);
        }
    }
    void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
            GameData.bosslevel = true;
            go= true;
            PlayerPrefs.SetString("savedLevel", SceneManager.GetActiveScene().name);
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
				bosslevel = GameData.bosslevel,
				score = GameData.score,
        	};
			string jsonInfo = JsonUtility.ToJson(newData,true);
        	File.WriteAllText(path , jsonInfo);
        	Debug.Log("寫入完成");
        }
    }
}
