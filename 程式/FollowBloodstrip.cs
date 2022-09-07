using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FollowBloodstrip : MonoBehaviour {
    
    /// <summary>
    /// 跟随目标
    /// </summary>
    public  Transform Target;
    /// <summary>
    /// 主摄像机
    /// </summary>
    private Camera maincamera;
	void Start () {
    
    }
	
	
	void Update () {
    
        if (Target!=null)
        {
    
        	  //把目标坐标转换为屏幕坐标
            Vector3 pos = maincamera.WorldToScreenPoint(Target.position);
            transform.position = pos;
        }
	
	}
}