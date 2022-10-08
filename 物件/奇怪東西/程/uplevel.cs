using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uplevel : MonoBehaviour
{
    private bool go=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(go && transform.position.y<=15.5f){
            gameObject.transform.position += new Vector3(0, 0.1f, 0);
        }
        else if(transform.position.y>=-1.4f){
            go= false;
            gameObject.transform.position += new Vector3(0, -0.1f, 0);
        }
    }
    void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
            go= true;
        }
    }
}
