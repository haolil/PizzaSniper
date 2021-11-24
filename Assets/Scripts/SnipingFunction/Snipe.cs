using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snipe : MonoBehaviour
{
    public Transform scope;
    public bool aimCheck, windowCheck;
    public float scopeZoom;
    TargetCheck targetCheck;
    public Vector3 scopeKick;
    public float kickWait;
    public bool isKicking;
    public float fireRate;
    public int magSize;
    public int currentBullet;
    public float reloadSpeed;
    public bool canShoot;
    private AudioSource _shootSoundAudioSource;
    public AudioClip shoot, reload, miss, hit;
    public float hitCount;
    public float missCount;
    public PineappleAI Pineapple;
    public WindowBreak windowBreak;

    //public int firingModeSwitch;
    //public bool semiAuto;
    //public bool fullAuto;
    //public bool burstFire;

    void Start()
    {
        _shootSoundAudioSource = GetComponent<AudioSource>();
        targetCheck = GetComponentInChildren<TargetCheck>();
        scope = this.transform;
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
        ShootGun();
        if (Input.GetMouseButtonDown(0) && currentBullet > 0 && canShoot)
        {
            BulletCount();
            if (Time.timeScale > 0)
            {
                if (windowBreak)
                {
                    windowBreak.CheckValue();
                    windowBreak = null;
                }

                if (Pineapple)
                {
                    Pineapple.PineappleHit();
                    Pineapple = null;
                }

                _shootSoundAudioSource.PlayOneShot(shoot);

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

    void ShootGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null && hit.collider.tag == "Enemy" || hit.collider.tag == "Window")
            {
                this.GetComponentInParent<Snipe>().aimCheck = true;
                if (hit.collider.tag == "Enemy")
                {
                    Pineapple = hit.collider.gameObject.GetComponent<PineappleAI>();
                }
                else if (hit.collider.tag == "Window")
                {
                    windowBreak = hit.collider.gameObject.GetComponent<WindowBreak>();
                }
            }
            else
            {
                this.GetComponentInParent<Snipe>().aimCheck = false;
                if (hit.collider.tag == "Enemy")
                {
                    Pineapple = null;
                }
                else if (hit.collider.tag == "Window")
                {
                    windowBreak = null;
                }
            }
        }
    }

    public void HitCheck()
    {
        ScopeKick();
        if (aimCheck)
        {
            hitCount++;
            StartCoroutine(HitWait());
            aimCheck = false;
        }
        else
        {
            StartCoroutine(MissWait());
            missCount++;
        }

        if (windowCheck)
        {
            StartCoroutine(HitWait());
            missCount--;
            aimCheck = false;
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
        _shootSoundAudioSource.PlayOneShot(reload);
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
    public IEnumerator HitWait()
    {
        yield return new WaitForSeconds(0.1f);
        _shootSoundAudioSource.PlayOneShot(hit);
    }
    public IEnumerator MissWait()
    {
        yield return new WaitForSeconds(0.1f);
        _shootSoundAudioSource.PlayOneShot(miss);
    }
}
