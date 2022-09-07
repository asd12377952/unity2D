using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPlayer : MonoBehaviour
{
    //在這裡設置人物所會用到的動畫
	public Sprite[] run;
	public float runFrameRate = 8.0f;
	public Sprite[] jump;
	public float jumpFrameRate = 8.0f;
    public AudioClip jumpSound;

	//各種人物動畫的變量
	private CharacterController controller;
	private float counter = 0.0f;
	private int i = 0;
	private SpriteRenderer rend;
	private bool isJumping = false;
    private Vector3 vel;
    private float jumpCounter = 0.0f;
	
	void Start () {
		controller = GetComponent<CharacterController>();
		rend = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		if(gameObject.transform.position.y>(-2) && isJumping){
			jumpCounter += Time.deltaTime;
			vel.y -= Time.deltaTime*30;
		}else{
			jumpCounter = 0.0f;
			vel.y = 0;
            isJumping = false;
		}
		
        //同樣在地面速度不是趨近於0的話就是走動並撥放run
        if(gameObject.transform.position.y <= (-2)){
            counter += Time.deltaTime*runFrameRate;
            if(counter > i && i < run.Length){
                rend.sprite = run[i];
                i += 1;
            }
            //讓動畫無限輪播
            if(counter > run.Length){
                counter = 0.0f;
                i = 0;
            }
        }
		//如果人物不是在地面
        //如果人物還不是jump的動畫以及Y軸速度大於設定值時播放jump動畫
		if(Random.Range(0,400)==200 && Random.Range(0,5)==2 && gameObject.transform.position.y<=(-2)){
            if(jumpCounter < 0.1f){
                isJumping = true;
                vel.y = 12.0f;
                jumpCounter = 0.1f;
                rend.sprite = jump[0];
                GetComponent<AudioSource>().PlayOneShot(jumpSound);
            }
        }
        //應用動作向量加速度到玩家
		controller.Move(vel*Time.deltaTime);
    }
}
