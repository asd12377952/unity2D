using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class defeat : MonoBehaviour
{
    public GameObject defeatWindow;

    void Start()
    {
        defeatWindow.gameObject.SetActive(false);
    }
    void Update()
    {
        if(GameData.hp<=0 && GameData.score<=0)
        {
            defeatWindow.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
