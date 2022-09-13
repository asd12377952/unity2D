using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class _exp : MonoBehaviour
{
	public RectTransform exp;
    public GameObject lv;
    
    // Start is called before the first frame update
    void Start()
    {
        lv.GetComponent<TextMeshProUGUI>().text="LV"+GameData.lv;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.lv<15){
            exp.sizeDelta = new Vector2(GameData.exp, exp.sizeDelta.y);
            if(GameData.exp>=250){
                GameData.exp -=250;
                lv_up();
            }
        }
        else{
            exp.sizeDelta = new Vector2(250, exp.sizeDelta.y);
        }

    }
    void lv_up(){
        GameData.lv+=1;
        GameData.point+=1;
        lv.GetComponent<TextMeshProUGUI>().text="LV"+GameData.lv;
    }
}
