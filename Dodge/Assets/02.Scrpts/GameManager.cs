using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float survivetime;
    private bool isGameover;
   
    void Start()
    {
        survivetime = 0;
        isGameover = false; 
    }

    void Update()
    {
        if(!isGameover)
        {
            survivetime += Time.deltaTime;
            timeText.text = "Time:" + (int)survivetime;
        }
        else{
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if(survivetime>bestTime)
        {
            bestTime = survivetime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time:" + (int)bestTime;
    }
}
