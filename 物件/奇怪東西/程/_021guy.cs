using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _021guy : MonoBehaviour
{
    //走速
	public float runSpeed = 4.0f;
	//射擊音效
	//public AudioClip shootSound;
	//射擊子彈
	public GameObject enemyBullet;
	public float bulletSpeed = 16.0f;
	public Transform bulletPosition;
	public float shuttime = 0.5f;
	
	//各種變量
	private CharacterController controller;
	private GameObject target;
	private float frameRate = 8.0f;
	private bool shooting = false;
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

		/*foreach(GameObject en in enemies)  {
			if (en.GetComponent<Collider>() != GetComponent<Collider>()) {
				Physics.IgnoreCollision(en.GetComponent<Collider>(), GetComponent<Collider>());
			}
		}*/
	}
	
	void Update () {
		//重力
		if(!controller.isGrounded){
			vel.y -= Time.deltaTime*80;
		}else{
			vel.y = -1;
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
			transform.localScale = new Vector3(-origX,transform.localScale.y,transform.localScale.z);
		}
		if(target.transform.position.x < transform.position.x){
			transform.localScale = new Vector3(origX,transform.localScale.y,transform.localScale.z);
		}
		
		//如果接近至設定距離將開始攻擊並撥放攻擊動畫
		if(distance < 15 && ydistance < 8){
			//如果距離在10~15之間又沒有在射擊的狀態下.目標在左邊就設為負值向左走.右邊為正值向右走
			if(distance > 10 && distance < 15 && !shooting){
				if(target.transform.position.x < transform.position.x){
					vel.x = -runSpeed;
				}
				if(target.transform.position.x > transform.position.x){
					vel.x = runSpeed;
				}
			}
			if(shooting){
				vel.x = 0;
			}
			//當距離足夠時才會發射子彈
			if(distance < 10 && shooting == false){
				StartCoroutine(shootBullet());
			}
		}
		
		//怪物掉落到限制高度要消失掉
		if(transform.position.y < -10){
			Destroy(gameObject);
		}
		
		//應用移動
		controller.Move(vel*Time.deltaTime);
	}
	
	//怪物發射子彈將會應用這個函數
	public IEnumerator shootBullet () {
		vel.x = 0;
		shooting = true;
		//發射前會稍微等待一下下讓玩家注意到
		yield return new WaitForSeconds(shuttime);
		//撥放射擊音效
		//GetComponent<AudioSource>().PlayOneShot(shootSound);
		//產生子彈
		GameObject bullet = Instantiate(enemyBullet, bulletPosition.position, Quaternion.Euler(0,0,0)) as GameObject;
		//設置速度與子彈.如果是左邊就設為負值.右邊為正
		bullet.GetComponent<Rigidbody>().velocity = new Vector3((target.transform.position.x-bulletPosition.position.x)*bulletSpeed,(target.transform.position.y-bulletPosition.position.y)*bulletSpeed,0);
		//發射完後也要有空檔準備再次觸發射擊條件
		yield return new WaitForSeconds(shuttime);
		shooting = false;
	}
}