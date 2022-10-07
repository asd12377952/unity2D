using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victory : MonoBehaviour
{
    public GameObject victoryWindow;
    public GameObject boss;

    void Start()
    {
        victoryWindow.gameObject.SetActive(false);

    }
    void Update()
    {
        if(boss == null)
        {
            victoryWindow.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
