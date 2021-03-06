using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    Timer timer;
    public GameObject pauseMenu, phase1, phase2, phase2Credits, phase2Controls;
    public bool paused;
    public GameObject snipe, blur;
    ScopeController scopeController;
    GunController gunController;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
        scopeController = FindObjectOfType<ScopeController>();
        gunController = FindObjectOfType<GunController>();
    }

    void Update()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                snipe.SetActive(false);
                blur.SetActive(false);
                paused = true;
                timer.timerStarted = false;
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
            snipe.SetActive(true);
            blur.SetActive(true);
            paused = false;
            timer.timerStarted = true;
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
        Cursor.visible = false;
        snipe.SetActive(true);
        blur.SetActive(true);
        paused = false;
        timer.timerStarted = true;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        phase1.SetActive(true);
        phase2.SetActive(false);
        phase2Credits.SetActive(false);
        phase2Controls.SetActive(false);
    }

    public void Quit()
    {
        Destroy(scopeController);
        Destroy(gunController);
    }
}