using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string firstPlay = "FirstPlay";
    private static readonly string backgroundPref = "backgroundPref";
    private static readonly string soundEffectPref = "soundEffectPref";
    private int firstPlayInt;
    public Slider backgroundSlider, soundEffectsSlider;
    private float backgroughFloat, soundEffectsFloat;
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
            backgroughFloat = 0.25f;
            soundEffectsFloat = 0.25f;
            backgroundSlider.value = backgroughFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            PlayerPrefs.SetFloat(backgroundPref, backgroughFloat);
            PlayerPrefs.SetFloat(soundEffectPref, soundEffectsFloat);
            PlayerPrefs.SetInt(firstPlay, -1);
        }
        else
        {
            backgroughFloat = PlayerPrefs.GetFloat(backgroundPref);
            backgroundSlider.value = backgroughFloat;
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
        backgroughFloat = PlayerPrefs.GetFloat(backgroundPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(soundEffectPref);

        backgroundAudio.volume = backgroughFloat;

        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;
        }
    }
}
