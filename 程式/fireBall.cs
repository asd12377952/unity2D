using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBall : MonoBehaviour
{
    public float range;
    public float speed;
    public int damage;
    private Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {
        Pos = gameObject.transform.position;
        gameObject.transform.position += new Vector3(0, range, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Pos = gameObject.transform.position;
        transform.RotateAround(Pos, new Vector3(0, 0, 1), 360 * Time.deltaTime * speed);
    }
    void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
			other.SendMessage("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
    }
}
