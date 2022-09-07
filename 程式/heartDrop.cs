using UnityEngine;
using System.Collections;

public class heartDrop : MonoBehaviour {
	//給它一點力量並且以亂數的方式掉落
	void Start () {
		GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-6,6),Random.Range(4,8),0);
	}
}
