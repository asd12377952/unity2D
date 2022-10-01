using UnityEngine;
using System.Collections;

public class deathAnimation : MonoBehaviour {

	//死亡動畫的程式，用來將角色及怪物死亡時撥放的動畫
	public Sprite[] deathSprites;
	//動畫撥放的速度
	public float frameRate = 12.0f;
	//音效
	public AudioClip deathSound;
	//設置計數器
	private float counter = 0.0f;
	private int i = 0;
	private SpriteRenderer rend;
	
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		//死亡時撥放死亡音效
		GetComponent<AudioSource>().PlayOneShot(deathSound);
	}
	
	void Update () {
		//計數器來控制撥放的動畫與它的撥放速度
		counter += Time.deltaTime*frameRate;
		if(counter > i && i < deathSprites.Length){
			rend.sprite = deathSprites[i];
			i += 1;
		}
		//當動畫撥放完後要消去這個物件
		if(counter > deathSprites.Length){
			Destroy(gameObject);
		}
	}
}
