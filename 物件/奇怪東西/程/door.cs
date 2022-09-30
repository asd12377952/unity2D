using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject door0;
    public Sprite[] door1;

    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = door0.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.bosslevel){
            rend.sprite = door1[0];
            door0.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
