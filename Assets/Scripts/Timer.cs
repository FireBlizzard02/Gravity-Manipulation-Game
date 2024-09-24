using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timerText; // Reference to TextMesh Pro UI element

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
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                EndGame();
            }
        }
    }

    // Function to update the displayed timer
    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Clamp(timeToDisplay, 0, Mathf.Infinity);
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Display in MM:SS format
    }

    void EndGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        
        Application.Quit();
        #endif
    }
}
