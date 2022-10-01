using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class emenyHp : MonoBehaviour
{
	public RectTransform hpbar;
    public GameObject target;
    public GameObject hp;
    
	void Start ()
	{
		
	}
	void Update ()
	{
        float _value = target.GetComponent<enemyHealth>().health;
		Vector2 targetP = Camera.main.WorldToScreenPoint (hp.transform.position);
        hpbar.sizeDelta = new Vector2(_value*10, hpbar.sizeDelta.y);
        hpbar.position= targetP ;
	}
}