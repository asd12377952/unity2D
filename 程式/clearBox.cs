using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearBox : MonoBehaviour
{
    public GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(boss == null){
			Destroy(gameObject);
			Debug.Log("打敗BOSS");
        }
    }
}
