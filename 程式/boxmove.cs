using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxmove : MonoBehaviour
{
	//子彈的飛行時間為一秒，如果時間太長或不消失的話子彈會一直線的飛行下去
	public float boxLife = 0.6f;
	//計數器與變量
	private float lifeCounter = 0.0f;
	
	void Update () {
		//加上計數器的變量
		lifeCounter += Time.deltaTime;
		
		//如果計數器大於設定的秒速(目前設定為1秒)就要毀掉這個物件
		if(lifeCounter > boxLife){
			Destroy(gameObject);
		}
	}

	//攻擊標記tag為Player的玩家並且摧毀物件
	void OnTriggerEnter (Collider other){
		if(other.tag == "box"){
			Destroy(gameObject);
		}
	}
}

