using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class playerHealth : MonoBehaviour {
	
	//受到撞擊的聲音
	public AudioClip hitSound;
	//死亡動畫
	public GameObject deathAnim;

	//碰到補血道具的音效
	public AudioClip heartSound;
	
	//設置死亡為否
	private bool dead = false;
	//設置可接受傷害為是
	private bool canGetHurt = true;
	//渲染2D圖形
	private SpriteRenderer rend;
	//血量設定
	public RectTransform HealthBar,Hurt;
	private int def = GameData.def;

    //血量條
    void Update()

    {
        //將綠色血條同步到當前血量長度

        HealthBar.sizeDelta = new Vector2(GameData.hp, HealthBar.sizeDelta.y);

        //呈現傷害量

        if (Hurt.sizeDelta.x > HealthBar.sizeDelta.x)

        {

            //讓傷害量(紅色血條)逐漸追上當前血量

            Hurt.sizeDelta += new Vector2(-2, 0)*Time.deltaTime*10;

        }
		def = GameData.def;
		if(GameData.score<0)
		{
			GameData.score=0;
		}

    }
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		//將2D渲染設為關閉
	}
	//如果在可以接受傷害與非死亡的狀態下受到攻擊
	//播放受傷音效
	//減少血量
	//確認血量並重製可受到傷害
	void takeDamage (int amount) {
		if(canGetHurt && !dead){
			canGetHurt = false;
			GetComponent<AudioSource>().PlayOneShot(hitSound);
			GameData.hp -= (amount-def);
			GameData.score -= 1;
			StartCoroutine(checkHealth());
			StartCoroutine(resetCanHurt());
		}
	}
	
	//待在怪物或是陷阱上受到傷害
	//這裡設定受到的傷害為1,調到100或許就是所謂的超困難遊戲
	void OnTriggerStay (Collider other){
		if(other.tag == "enemy" || other.tag == "trap"){
			if(canGetHurt && !dead){
				canGetHurt = false;
				GetComponent<AudioSource>().PlayOneShot(hitSound);
				GameData.hp -= (50-def);
				GameData.score -= 1;
				StartCoroutine(checkHealth());
				StartCoroutine(resetCanHurt());
			}
		}
		//碰到補血道具要增加血量
		if(other.GetComponent<Collider>().tag == "heart"){
			Destroy(other.gameObject);
			addHealth();
		}
	}
	
	//碰撞到怪物或是陷阱時受到傷害,若只有碰撞傷害若玩家不動就只會觸發一次
	/*void OnCollisionStay (Collision other){
		if(other.collider.tag == "enemy" || other.collider.tag == "trap"){
			if(canGetHurt && !dead){
				canGetHurt = false;
				GetComponent<AudioSource>().PlayOneShot(hitSound);
				GameData.hp -= (50-def);
				StartCoroutine(checkHealth());
				StartCoroutine(resetCanHurt());
			}
		}
	}*/
	
	//重製可以受到傷害的各種數值與設定
	//受到傷害時變為紅色(1.0f,0.5f,0.5f,1.0f)就是CMYK
	//受到傷害後的無敵時間設為1秒,調到100或許就是所謂的超簡單遊戲
	//結束無敵時間後記得將顏色條回全白,不然就會保持在紅色的狀態
	public IEnumerator resetCanHurt () {
		if(GameData.hp>0)
		{
			rend.color = new Color(1.0f,0.5f,0.5f,0.5f);
			yield return new WaitForSeconds(0.5f);
			rend.color = new Color(1.0f,1.0f,1.0f,1.0f);
			canGetHurt = true;
		}
		
	}
	
	//當受到傷害時確認血量
	public IEnumerator checkHealth () {
		// 如果血量少於等於0並且不是死亡的狀態下宣告死亡成立	
		if(GameData.hp <= 0 && dead == false){
			dead = true;
			//死亡動畫的位置
			Instantiate(deathAnim, transform.position, Quaternion.Euler(0,180,0));
			BroadcastMessage("died", SendMessageOptions.DontRequireReceiver);
			rend.color = new Color(1.0f,1.0f,0.5f,0f);
			//重新復活時間為2秒
			yield return new WaitForSeconds(2);
			//重新讀取關卡
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			GameData.hp = 250;
			GameData.exp = 0;
			yield return new WaitForSeconds(1);
			rend.color = new Color(1.0f,1.0f,1.0f,1.0f);
		}
	}
	
	//添加血量
	void addHealth () {
		GetComponent<AudioSource>().PlayOneShot(heartSound);
		//吃到愛心所增加的血量
		GameData.hp += 50;
		//如果吃的血量超過設定值就不要再增加了
		if(GameData.hp > 250){
			GameData.hp = 250;
		}
		Hurt.sizeDelta = new Vector2(GameData.hp, Hurt.sizeDelta.y);
	}
}
