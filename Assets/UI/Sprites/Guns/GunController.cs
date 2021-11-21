using UnityEngine;

public class GunController : MonoBehaviour
{
    public int currentGun;
    public string SelectedGun = "SelectedGun";

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void GunOne()
    {
        currentGun = 0;
        PlayerPrefs.SetInt(SelectedGun, 0);
    }

    public void GunTwo()
    {
        currentGun = 1;
        PlayerPrefs.SetInt(SelectedGun, 1);
    }

    public void GunThree()
    {
        currentGun = 2;
        PlayerPrefs.SetInt(SelectedGun, 2);
    }

    public void GunFour()
    {
        currentGun = 3;
        PlayerPrefs.SetInt(SelectedGun, 3);
    }

    public void GunFive()
    {
        currentGun = 4;
        PlayerPrefs.SetInt(SelectedGun, 4);
    }

    public void GunSix()
    {
        currentGun = 5;
        PlayerPrefs.SetInt(SelectedGun, 5);
    }
}