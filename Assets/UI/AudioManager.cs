using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string firstPlay = "FirstPlay";
    private static readonly string backgroundPref = "backgroundPref";
    private static readonly string soundEffectPref = "soundEffectPref";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroundFloat, soundEffectsFloat;
    public AudioSource backgroundAudio;
    public AudioSource[] soundEffectsAudio;
    
    void Awake()
    {
        ContinueSettings();
    }

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(firstPlay);

        if (firstPlayInt == 0)
        {
            backgroundFloat = 0.25f;
            soundEffectsFloat = 0.25f;
            backgroundSlider.value = backgroundFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(backgroundPref, backgroundFloat);
            PlayerPrefs.SetFloat(soundEffectPref, soundEffectsFloat);
            PlayerPrefs.SetInt(firstPlay, -1);
        }
        else
        {
            backgroundFloat = PlayerPrefs.GetFloat(backgroundPref);
            backgroundSlider.value = backgroundFloat;
            soundEffectsFloat = PlayerPrefs.GetFloat(soundEffectPref);
            soundEffectsSlider.value = soundEffectsFloat;
        }
    }
    
    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(backgroundPref, backgroundSlider.value);
        PlayerPrefs.SetFloat(soundEffectPref, soundEffectsSlider.value);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        backgroundAudio.volume = backgroundSlider.value;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }

    private void ContinueSettings()
    {
        backgroundFloat = PlayerPrefs.GetFloat(backgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(soundEffectPref);

        backgroundAudio.volume = backgroundFloat;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            if (soundEffectsAudio[i] != null)
            {
                soundEffectsAudio[i].volume = soundEffectsFloat;
            }
        }
    }

    public void SlowSound()
    {
        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            if (soundEffectsAudio[i] != null)
            {
                soundEffectsAudio[i].volume = 0;
            }
        }
        backgroundAudio.volume = 0;
        StartCoroutine(pauseTime());
    }
    
    IEnumerator pauseTime()
    {
        yield return new WaitForSecondsRealtime(3.7f);
        ContinueSettings();
    }
}