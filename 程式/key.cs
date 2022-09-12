using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject door;
	public Sprite[] door1;

    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = door.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
            Destroy(gameObject);
            rend.sprite = door1[0];
            door.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
