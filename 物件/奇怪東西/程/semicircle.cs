using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semicircle : MonoBehaviour
{
    public float range;
    public float speed;
    public int damage;
    private Vector3 Pos;
	private int i = 1;
    private float counter = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Pos = gameObject.transform.position;
        gameObject.transform.position += new Vector3(0, range, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Pos = gameObject.transform.position;
        if(i==1){
            transform.RotateAround(Pos, new Vector3(0, 0, 1), 360 * Time.deltaTime * -speed);
        }
        else{
            transform.RotateAround(Pos, new Vector3(0, 0, 1), 360 * Time.deltaTime * speed);
        }

        if(transform.localEulerAngles.z >20 && transform.localEulerAngles.z<160 && counter>2.0f){
            i = -i;
            Debug.Log(transform.localEulerAngles);
            counter=0.0f;
        }
        counter += Time.deltaTime;
    }
    void OnTriggerEnter (Collider other){
		if(other.tag == "Player"){
			other.SendMessage("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
    }
}

