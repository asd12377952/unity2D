using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour
{
    public GameObject enemyBullet;
	public float bulletX;
    public float bulletY;
	public float shuttime;



    private bool shooting = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shooting == false){
			StartCoroutine(shootBullet());
			}
    }
    public IEnumerator shootBullet () {
		shooting = true;
		//發射前會稍微等待一下下讓玩家注意到
		yield return new WaitForSeconds(shuttime);
		//產生子彈
		GameObject bullet = Instantiate(enemyBullet, gameObject.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
		//設置速度與子彈.如果是左邊就設為負值.右邊為正
		bullet.GetComponent<Rigidbody>().velocity = new Vector3(bulletX,bulletY,0);
		//發射完後也要有空檔準備再次觸發射擊條件
		yield return new WaitForSeconds(shuttime);
		shooting = false;
	}
}
