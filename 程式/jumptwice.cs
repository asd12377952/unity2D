using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumptwice : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
			Destroy(gameObject);
            GameData.jumpTwice=1;
            other.SendMessage("jump");
        }
	}
}
