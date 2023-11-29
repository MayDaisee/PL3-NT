using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms;

public class GameMasterTimer : MonoBehaviour
{

    public float timeSeconds = 300;
    public TextMeshProUGUI timerText;
    public GameObject LoseButton;

    // Update is called once per frame
    void Update()
    {

        timeSeconds -= Time.deltaTime;

        if (timeSeconds > 0)
        {
            TimeDisplay(timeSeconds);
        }

        else
        {
            timeSeconds = 0;
            LoseButton.gameObject.SetActive(true);
        }

    }

    void TimeDisplay(float displayedTime)
    {
      

        float minutes = Mathf.FloorToInt(displayedTime / 60);
        float seconds = Mathf.FloorToInt(displayedTime % 60);

        timerText.SetText("{0 00}{1 00}", minutes, seconds);

    }


}
