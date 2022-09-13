using UnityEngine;
using System.Collections;

public class facecrawl : MonoBehaviour {
	
	//爬行速度
	public float crawlSpeed = 4.0f;
	//貼圖動畫
	public Sprite[] crawl;
	//各種變量
	public bool canJump =false;

	private CharacterController controller;
	private float counter = 0.0f;
	private int i = 0;
	private GameObject target;
	private float frameRate = 8.0f;
	private SpriteRenderer rend;
	private float origX;
	private Vector3 vel;
	
	//怪物的AI
	void Start () {
		//找到玩家並朝著玩家前進.移動為水平X軸
		controller = GetComponent<CharacterController>();
		rend = GetComponent<SpriteRenderer>();
		target = GameObject.Find("player");
		Physics.IgnoreCollision(target.GetComponent<Collider>(), GetComponent<Collider>());
		origX = transform.localScale.x;
		//忽略與其他怪物物件的碰撞.加入標籤"enemy"讓怪物來辨識
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
		for(int j=0;j<enemies.Length;j++){
            if (enemies[j].GetComponent<Collider>() != GetComponent<Collider>()) {
				Physics.IgnoreCollision(enemies[j].GetComponent<Collider>(), GetComponent<Collider>());
			}
		}
	}
	
	void Update () {
		//重力
		if(!controller.isGrounded){
			vel.y -= Time.deltaTime*40;
		}else{
			vel.y = -1;
		}

		if(Random.Range(0,100)==50 && controller.isGrounded && canJump){
            vel.y = 12.0f;
        }

		//檢查玩家接近怪物之間的距離
		float distance = target.transform.position.x - transform.position.x;
		float ydistance = target.transform.position.y - transform.position.y;
		if(distance < 0){
			distance *= -1;
		}
		if(ydistance < 0){
			ydistance *= -1;
		}
		if(target.transform.position.x > transform.position.x){
			transform.localScale = new Vector3(origX,transform.localScale.y,transform.localScale.z);
		}
		if(target.transform.position.x < transform.position.x){
			transform.localScale = new Vector3(-origX,transform.localScale.y,transform.localScale.z);
		}
		//如果距離在10~15之間.目標在左邊就設為負值向左走.右邊為正值向右走
		if (distance < 15 && ydistance < 5) {
			counter += Time.deltaTime * frameRate;
				if (target.transform.position.x < transform.position.x) {
					vel.x = -crawlSpeed;
				}
				if (target.transform.position.x > transform.position.x) {
					vel.x = crawlSpeed;
				}
				if (counter > i && i < crawl.Length) {
					rend.sprite = crawl [i];
					i += 1;
				}
				if (counter > crawl.Length) {
					counter = 0.0f;
					i = 0;
				}
		}
		//怪物掉落到限制高度要消失掉
		if(transform.position.y < -10){
			Destroy(gameObject);
		}
		//應用移動
		controller.Move(vel*Time.deltaTime);
	}
	
	
}
