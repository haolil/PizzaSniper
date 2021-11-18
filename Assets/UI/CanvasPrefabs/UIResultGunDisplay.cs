using UnityEngine;
using UnityEngine.UI;

public class UIResultGunDisplay : MonoBehaviour
{
    public Image gunUI;
    public Sprite gun1, gun2, gun3, gun4, gun5, gun6;
    GunController gunController;

    private void Start()
    {
        gunController = FindObjectOfType<GunController>();

        switch (gunController.currentGun)
        {
            case 0:
                gunUI.sprite = gun1;
                break;
            case 1:
                gunUI.sprite = gun2;
                break;
            case 2:
                gunUI.sprite = gun3;
                break;
            case 3:
                gunUI.sprite = gun4;
                break;
            case 4:
                gunUI.sprite = gun5;
                break;
            case 5:
                gunUI.sprite = gun6;
                break;
        }
    }
}