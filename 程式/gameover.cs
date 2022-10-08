using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameover : MonoBehaviour
{
    private string text;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if(GameData.score>=100){
            text="PERFECT CLEAR";
        }
        else if(GameData.score>=80){
            text="EXCELLENT CLEAR";
        }
        else if(GameData.score>=60){
            text="GENERAL CLEAR";
        }
        else if(GameData.score>=20){
            text="INADEQUETE CLEAR";
        }
        else if(GameData.score>=0){
            text="Noob";
        }
        GetComponent<TextMeshProUGUI>().text=text;
    }
}
