using UnityEngine;
using UnityEngine.UI; 

public class TimerManager : MonoBehaviour
{
    public float timeRemaining = 60; 
    public bool timerIsRunning = false;

    public Text timerText; 

    private void Start()
    {
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }

        timerText.text = Mathf.Floor(timeRemaining).ToString();
    }
}

