using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu, phase1, phase2, phase2Credits, phase2Controls;

    void Update()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            phase1.SetActive(true);
            phase2.SetActive(false);
            phase2Credits.SetActive(false);
            phase2Controls.SetActive(false);
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        phase1.SetActive(true);
        phase2.SetActive(false);
        phase2Credits.SetActive(false);
        phase2Controls.SetActive(false);
    }
}
