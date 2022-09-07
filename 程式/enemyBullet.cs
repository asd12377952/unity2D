using UnityEngine;
using System.Collections;

public class enemyBullet : MonoBehaviour {

	//設定子彈的威力
	public int damage = 50;
	//子彈的飛行時間為一秒，如果時間太長或不消失的話子彈會一直線的飛行下去
	public float bulletLife = 0.6f;
	//計數器與變量
	private float lifeCounter = 0.0f;
	private int i=0;

	
	void Update () {
		//加上計數器的變量
		lifeCounter += Time.deltaTime;
		
		//如果計數器大於設定的秒速(目前設定為1秒)就要毀掉這個物件
		if(lifeCounter > bulletLife){
			Destroy(gameObject);
		}
	}

	//攻擊標記tag為Player的玩家並且摧毀物件
	void OnTriggerEnter (Collider other){
		if(other.tag == "Player"&& i==0){
			i=1;
			other.SendMessage("takeDamage", damage, SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
		if(other.tag == "box"){
			Destroy(gameObject);
		}
	}
}
