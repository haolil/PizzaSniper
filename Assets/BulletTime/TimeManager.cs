using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    bool canSlow, resetTime;
    public AudioClip start, stop;
    AudioSource audioSource;
    AudioManager audioManager;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (resetTime)
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
        
        if (Time.timeScale == 1)
        {
            canSlow = true;
        }

        if (Input.GetMouseButtonDown(2))
        {
            BulletTime();
        }
    }

    public void BulletTime()
    {
        if (canSlow)
        {
            canSlow = false;
            resetTime = false;
            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            audioManager.SlowSound();
            audioSource.pitch = 1;
            audioSource.PlayOneShot(start);
            StartCoroutine(PauseTime());
        }
    }

    IEnumerator PauseTime()
    {
        yield return new WaitForSecondsRealtime(2f);
        resetTime = true;
        audioSource.pitch = -0.4f;
        audioSource.loop = true;
        audioSource.clip = stop;
        audioSource.Play();
        yield return new WaitForSecondsRealtime(0.5f);
        audioSource.loop = false;
    }
}