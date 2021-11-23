using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snipe : MonoBehaviour
{
    public Transform scope;
    public Transform aim;
    public bool aimCheck;
    public float scopeZoom;
    TargetCheck targetCheck;

    //public int firingModeSwitch;
    //public bool semiAuto;
    //public bool fullAuto;
    //public bool burstFire;
    public Vector3 scopeKick;
    public float kickWait;
    public bool isKicking;
    public float fireRate;
    public int magSize;
    public int currentBullet;
    public float reloadSpeed;
    public bool canShoot;
    private AudioSource _shootSoundAudioSource;
    public float hitCount;
    public float missCount;

    void Start()
    {

        _shootSoundAudioSource = GetComponent<AudioSource>();
        targetCheck = GetComponentInChildren<TargetCheck>();
        scope = this.transform;
        aim = scope.GetChild(0);
        Cursor.visible = false;
        //firingModeSwitch = 3;
        currentBullet = magSize;
        canShoot = true;
    }

    void Update()
    {
        FollowMouse();
        //FiringModeButton();
        //FireModeSet(firingModeSwitch);
        shootFunction();
        Reload();
    }

    public void FollowMouse()
    {
        if (!isKicking)
        {
            Vector3 tempPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            scope.position = new Vector3(tempPosition.x, tempPosition.y, 0);
        }

    }

    public void shootFunction()
    {
        
        if (Input.GetMouseButtonDown(0) && currentBullet > 0 && canShoot)
        {
            BulletCount();

            if (Time.timeScale > 0)
            {

                if (targetCheck.Pineapple)
                {
                    targetCheck.Pineapple.PineappleHit();
                    targetCheck.Pineapple = null;
                }

                _shootSoundAudioSource.Play();

                HitCheck();
                StartCoroutine(FireWait());
            }

        }
        else if(Input.GetMouseButtonDown(0) && currentBullet == 0 && canShoot)
        {
            if(Time.timeScale > 0)
            {
                StartCoroutine(ReloadWait());
            }
        }
    }

    public void HitCheck()
    {
        ScopeKick();
        if (aimCheck)
        {
            hitCount++;
            aimCheck = false;
        }
        else
        {
            missCount++;
        }
    }


    //public void FiringModeButton()
    //{
    //    if (Input.GetKeyDown(KeyCode.B))
    //    {
    //        if (firingModeSwitch > 1)
    //        {
    //            firingModeSwitch-=1;
    //        }
    //        else
    //        {
    //            firingModeSwitch = 3;
    //        }
    //    }
    //}

    //public void FireModeSet(int firingModeSwitch)
    //{
    //    switch (firingModeSwitch)
    //    {
    //        case 3:
    //            semiAuto = true;
    //            fullAuto = false;
    //            burstFire = false;
    //            break;
    //        case 2:
    //            semiAuto = false;
    //            fullAuto = true;
    //            burstFire = false;
    //            break;
    //        case 1:
    //            semiAuto = false;
    //            fullAuto = false;
    //            burstFire = true;
    //            break;
    //        default:
    //            print("Firingmode not set");
    //            break;
    //    }
    //}

    public void BulletCount()
    {
        if (currentBullet > 0)
        {
            currentBullet--;
        }
    }

    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) || Input.GetMouseButtonDown(1))
        {
            StartCoroutine(ReloadWait());
        }
    }

    public void ScopeKick()
    {
        scope.position += scopeKick;
        StartCoroutine(KickWait());
    }


    public IEnumerator ReloadWait()
    {
        yield return new WaitForSeconds(reloadSpeed);
        currentBullet = magSize;
    }

    public IEnumerator FireWait()
    {
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public IEnumerator KickWait()
    {
        isKicking = true;
        yield return new WaitForSeconds(kickWait);
        isKicking = false;
    }
}
