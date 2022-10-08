using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {

	// 這個程式會附加到撥放器main Camera內，這裡死區deadZone設置為0，可以在unity內調到想要的效果
	public GameObject target;
	
	public float deadZone = 0;
	public bool followVertical = true;
	public bool followHorizontal = true;
	public float minimumHeight = 0;

	public GameObject boss;
	public GameObject next;
	private bool n = true;
	
	void Start () {
		QualitySettings.vSyncCount = 0;   // 把垂直同步關掉
    	Application.targetFrameRate = 60;
		if(target == null){
			target = GameObject.Find("Player");
		}
	}
	
	void Update () {
		if(boss == null && n){
			next.gameObject.SetActive(true);
			Debug.Log("打敗BOSS");
			n=false;
		}

		if(target != null){
			//檢查移動的水平方向與死區，移動的水平Ｘ軸速度也要將死區數值加減近來
			if(followHorizontal == true){
				if (transform.position.x >= target.transform.position.x + deadZone){
					transform.position = new Vector3(target.transform.position.x+deadZone,transform.position.y,transform.position.z);
				}
				if (transform.position.x <= target.transform.position.x - deadZone){
					transform.position = new Vector3(target.transform.position.x-deadZone,transform.position.y,transform.position.z);
				}
			}
			
			//檢查移動的垂直方向與死區，移動的垂直Ｙ軸速度也要將死區數值加減近來
			if(followVertical == true){
				if (transform.position.y >= target.transform.position.y + deadZone){
					transform.position = new Vector3(transform.position.x, target.transform.position.y+deadZone, transform.position.z);
				}
				if (transform.position.y <= target.transform.position.y - deadZone){
					transform.position = new Vector3(transform.position.x, target.transform.position.y-deadZone, transform.position.z);
				}
			}
			
			//如果照相機碰到最低高度將不會再降低位置
			if(target.transform.position.y < minimumHeight){
				transform.position = new Vector3(transform.position.x, minimumHeight, transform.position.z);
			}
		}
	}
}
