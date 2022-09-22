using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetrap : MonoBehaviour
{
    public int x;
    public int y;
    public float speed;
    public float life;

    private float lifeCounter = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
		for(int j=0;j<enemies.Length;j++){
            if (enemies[j].GetComponent<Collider>() != GetComponent<Collider>()) {
				Physics.IgnoreCollision(enemies[j].GetComponent<Collider>(), GetComponent<Collider>());
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed) ;
        lifeCounter += Time.deltaTime;
		
		//如果計數器大於設定的秒速(目前設定為1秒)就要毀掉這個物件
		if(lifeCounter > life){
			Destroy(gameObject);
		}
    }
}
