using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;

    void Update()
    {
        if (!pauseMenu.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("P");
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            Debug.Log("NP");
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("NP");
    }
}
