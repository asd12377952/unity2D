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
        exp.sizeDelta = new Vector2(GameData.exp, exp.sizeDelta.y);
        if(GameData.exp>=250){
            GameData.exp -=250;
            lv_up();
        }
    }
    void lv_up(){
        if(GameData.lv<15){
            GameData.lv+=1;
            lv.GetComponent<TextMeshProUGUI>().text="LV"+GameData.lv;
            GameData.point+=1;
        }
        else{
            lv.GetComponent<TextMeshProUGUI>().text="LVMAX";
        }
    }
}
