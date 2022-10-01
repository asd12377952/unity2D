using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {
	//子彈的飛行時間為一秒，如果時間太長或不消失的話子彈會一直線的飛行下去
	private float bulletLife = GameData.bulletLife;
	//計數器與變量
	private float lifeCounter = 0.0f;
	private float damage = GameData.damage;
	private int i =0;


	void start(){
		damage = GameData.damage;
		bulletLife = GameData.bulletLife;
	}
	void Update () {
		//加上計數器的變量
		lifeCounter += Time.deltaTime;
		
		//如果計數器大於設定的秒速(目前設定為1秒)就要毀掉這個物件
		if(lifeCounter > bulletLife){
			Destroy(gameObject);
		}
	}
	//攻擊標記tag為enemy的怪物並且摧毀物件，如果把Destroy(gameObject);拿掉的話也可以做成貫通彈喔
	void OnTriggerEnter (Collider other){

		if(other.tag == "enemy"&& i==0){
			i=1;
			Destroy(gameObject);
			other.SendMessage("takeDamage", damage);
		}
		if(other.tag == "box"){
			Destroy(gameObject);
		}
	}
}
