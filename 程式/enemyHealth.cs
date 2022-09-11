using UnityEngine;
using System.Collections;

public class enemyHealth : MonoBehaviour {

	//如果怪物死了要出現死亡動畫
	public GameObject deathAnim;
	//將怪物打死會掉落愛心
	public GameObject heartDrop;
	//怪物血量與打擊音效
	public float health;
	public AudioClip hurtSound;
	
	private SpriteRenderer rend;
	private bool isDead = false;

	
	//當子彈擊中怪物時會受到傷害並撥放音效，當血量為０時將死亡設為成立撥放死亡動畫並設定一定範圍作為機率生產愛心，最後摧毀物件不然就是重置受傷顏色
	void takeDamage (float amount) {
		rend = GetComponent<SpriteRenderer>();
		if(!isDead){
			GetComponent<AudioSource>().PlayOneShot(hurtSound);
			health -= amount ;
			if(health <= 0){
				isDead = true;
				Instantiate(deathAnim, transform.position, Quaternion.Euler(0,180,0));
				int randNum = Random.Range(1,4);
				if(randNum == 2){
					Instantiate(heartDrop, transform.position, Quaternion.Euler(0,180,0));
				}
				Destroy(gameObject);
				GameData.exp = GameData.exp + 30 + GameData.exppoint;
			}else{
				StartCoroutine(resetColor());
			}
		}
	}
	
	//與玩家相同受到傷害時也會加上紅色來表示現在是受到傷害的狀態
	public IEnumerator resetColor () {
		var old = rend.color;
		yield return new WaitForSeconds (0.1f);
		rend.color = new Color(1.0f,0.25f,0.25f,0.5f);
		yield return new WaitForSeconds (0.1f);
		rend.color = old;
	}
}
