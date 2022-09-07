using UnityEngine;
using System.Collections;

public class playerAnimator : MonoBehaviour {
	
	//在這裡設置人物所會用到的動畫
	public Sprite[] idle;
	public float idleFrameRate = 8.0f;
	public Sprite[] run;
	public float runFrameRate = 8.0f;
	public Sprite[] jump;
	public float jumpFrameRate = 8.0f;
	public float frameRate = 8;
	
	//各種人物動畫的變量
	private CharacterController controller;
	private float counter = 0.0f;
	private int i = 0;
	private SpriteRenderer rend;
	private bool isJumping = false;
	
	void Start () {
		controller = GetComponent<CharacterController>();
		rend = GetComponent<SpriteRenderer>();
	}
	
	void Update () {
		//檢查速度來判定腳色的動作
		//因為需要平面移動與跳躍的判定所以需要X軸與Y軸的速度
		float xVelocity = controller.velocity.x;
		float yVelocity = controller.velocity.y;
		if(xVelocity < 0){
			xVelocity *= -1;
		}
		//如果X軸速度趨近0並且是在地面時撥放idle
		if(xVelocity < 0.25f){
			if(controller.isGrounded){
				counter += Time.deltaTime*idleFrameRate;
				if(counter > i && i < idle.Length){
					rend.sprite = idle[i];
					i += 1;
				}
				//讓動畫無限輪播
				if(counter > idle.Length){
					counter = 0.0f;
					i = 0;
				}
			}
		}else{
			//同樣在地面速度不是趨近於0的話就是走動並撥放run
			if(controller.isGrounded){
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
		}
		//如果人物不是在地面
		if(!controller.isGrounded){
			//如果人物還不是jump的動畫以及Y軸速度大於設定值時播放jump動畫
			if(!isJumping && yVelocity > 0.5f){
				isJumping = true;
				counter = 0.0f;
				i = 0;
			}
			if(isJumping){
				counter += Time.deltaTime*jumpFrameRate;
				if(counter > i && i < jump.Length){
					rend.sprite = jump[i];
					i += 1;
				}
			}
		}
		//如果人物回到了地面將停止jump動畫
		if(controller.isGrounded){
			isJumping = false;
		}
	}
}

