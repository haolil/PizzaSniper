using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snipe : MonoBehaviour
{
    public Transform scope;
    public Transform aim;
    public bool aimCheck;
    public float scopeZoom;

    public int firingModeSwitch = 1;
    public bool semiAuto;
    public bool fullAuto;
    public bool burstFire;
    public float fireRate;
    public int magSize;
    public float reloadSpeed;

    public float hitCount;
    public float missCount;


    // Start is called before the first frame update
    void Start()
    {
        scope = this.transform;
        aim = scope.GetChild(0);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
        shootFunction();
    }

    public void FollowMouse()
    {
        Vector3 tempPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        scope.position = new Vector3(tempPosition.x, tempPosition.y, 0);
    }

    public void shootFunction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HitCheck();
        }
    }

    public void HitCheck()
    {
        if (aimCheck)
        {
            hitCount++;
        }
        else
        {
            missCount++;
        }
    }

}
