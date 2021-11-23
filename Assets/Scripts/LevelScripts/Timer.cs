using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startTime, currentTime;
    public bool timerStarted = false, timerFinished;
    public Text timerUI;
    PauseMenu pauseMenu;
    public GameObject results;
    ScoreTracking scoreTracking;

    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        currentTime = startTime;
        timerStarted = true;
        timerUI.text = currentTime.ToString();
        scoreTracking = results.GetComponent<ScoreTracking>();
    }

    private void Update()
    {
        if (timerStarted)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                pauseMenu.enabled = false;
                timerStarted = false;
                currentTime = 0;
                timerUI.enabled = false;
                DeactivatePlayer();
                ShowResults();
            }
            timerUI.text = currentTime.ToString("f2");
        }

        if (timerFinished)
        {
            pauseMenu.enabled = false;
            timerStarted = false;
            timerUI.enabled = false;
            DeactivatePlayer();
            ShowResults();
        }
    }

    public void DeactivatePlayer()
    {
        //dont allow the player to use input
    }
    public void ShowResults()
    {
        results.SetActive(true);
        scoreTracking.FinalResults();
    }
}