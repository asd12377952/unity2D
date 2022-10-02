using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class score : MonoBehaviour
{
    string s;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        s="scores: ";
        int _value = GameData.score;
        s+=_value;
        //GetComponent<TextMesh>().text= (s);
        GetComponent<TextMeshProUGUI>().text= (s);
    }
}
