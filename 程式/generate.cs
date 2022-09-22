using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generate : MonoBehaviour
{
    public float deltaTime;
    public GameObject box;

    private bool i = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(i){
            StartCoroutine(go());
        }
    }
    public IEnumerator go () {
		i = false;
		//發射前會稍微等待一下下讓玩家注意到
		yield return new WaitForSeconds(deltaTime);
		//產生子彈
		GameObject bullet = Instantiate(box, gameObject.transform.position, Quaternion.Euler(0,0,0)) as GameObject;
		//發射完後也要有空檔準備再次觸發射擊條件
		yield return new WaitForSeconds(deltaTime);
		i = true;
	}
}
