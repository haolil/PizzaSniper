using UnityEngine;
using UnityEngine.UI;

public class UIResultGunDisplay : MonoBehaviour
{
    public Image gunUI;
    public Sprite gun1, gun2, gun3, gun4, gun5, gun6;
    GunController gunController;
    Snipe snipe;

    private void Start()
    {
        gunController = FindObjectOfType<GunController>();
        snipe = FindObjectOfType<Snipe>();

        switch (gunController.currentGun)
        {
            case 0:
                gunUI.sprite = gun1;
                snipe.fireRate = 0.5f;
                break;
            case 1:
                gunUI.sprite = gun2;
                snipe.fireRate = 0.4f;
                break;
            case 2:
                gunUI.sprite = gun3;
                snipe.fireRate = 0.3f;
                break;
            case 3:
                gunUI.sprite = gun4;
                snipe.fireRate = 0.2f;
                break;
            case 4:
                gunUI.sprite = gun5;
                snipe.fireRate = 0.1f;
                break;
            case 5:
                gunUI.sprite = gun6;
                snipe.fireRate = 0;
                break;
        }
    }
}