using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class restart : MonoBehaviour
{

    private Button Btn;
    // Start is called before the first frame update
    void Start()
    {
        Btn = GetComponent<Button>();
        Btn.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RestartGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("menu");
    }
}
