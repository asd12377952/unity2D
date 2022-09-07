using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class text : MonoBehaviour
{
    public GameObject target;
    string s;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        s="";
        float _value = target.GetComponent<enemyHealth>().health;
        for(int i=1;i<=_value;i++){
            s=s+"*";
        }
        GetComponent<TextMesh>().text= (s);
    }
}
