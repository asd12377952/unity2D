using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosslevel : MonoBehaviour
{
    private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("player");
        if(GameData.bosslevel){
            gameObject.transform.localPosition = new Vector3(271, 61, 0);
            target.transform.position = new Vector3(0, 0.1f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.bosslevel && transform.localPosition.y<=2.3f){
            gameObject.transform.position += new Vector3(0, 0.1f, 0);
        }
    }
    void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
            GameData.bosslevel = true;
        }
    }
}
