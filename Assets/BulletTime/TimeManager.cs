using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    bool canSlow, resetTime;

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
            StartCoroutine(PauseTime());
        }
    }

    IEnumerator PauseTime()
    {
        yield return new WaitForSecondsRealtime(2f);
        resetTime = true;
    }
}