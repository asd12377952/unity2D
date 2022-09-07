using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class stop : MonoBehaviour
{
    public GameObject point;
    public Button atk,def,dis;
	public RectTransform ATK,DEF,DIS;

    // Start is called before the first frame update
    void Start()
    {
        ATK.sizeDelta = new Vector2((GameData.damage-1.0f)*250, ATK.sizeDelta.y);
        DEF.sizeDelta = new Vector2(GameData.def*10, DEF.sizeDelta.y);
        DIS.sizeDelta = new Vector2((GameData.bulletLife-0.3f)*1000, DIS.sizeDelta.y);
        atk.onClick.AddListener(_atk);
        def.onClick.AddListener(_def);
        dis.onClick.AddListener(_dis);

    }

    // Update is called once per frame
    void Update()
    {
        point.GetComponent<TextMeshProUGUI>().text="point : "+GameData.point;
    }
    void _atk(){
        if(GameData.point > 0 && GameData.damage < 2.0f){
            GameData.damage+=0.2f;
            GameData.point-=1;
            ATK.sizeDelta = new Vector2((GameData.damage-1.0f)*250, ATK.sizeDelta.y);
        }
    }
    void _def(){
        if(GameData.point > 0 && GameData.def < 25){
            GameData.def+=5;
            GameData.point-=1;
            DEF.sizeDelta = new Vector2(GameData.def*10, DEF.sizeDelta.y);
        }
    }
    void _dis(){
        if(GameData.point > 0 && GameData.bulletLife < 0.55f){
            GameData.bulletLife+=0.05f;
            GameData.point-=1;
            DIS.sizeDelta = new Vector2((GameData.bulletLife-0.3f)*1000, DIS.sizeDelta.y);
        }
    }
}
