using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCheck : MonoBehaviour
{
    public PineappleAI Pineapple;
    WindowBreak windowBreak;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            this.GetComponentInParent<Snipe>().aimCheck = true;
            Pineapple = collision.gameObject.GetComponent<PineappleAI>();
        }

        if (collision.tag == "Window")
        {
            this.GetComponentInParent<Snipe>().aimCheck = true;
            windowBreak = collision.gameObject.GetComponent<WindowBreak>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            this.GetComponentInParent<Snipe>().aimCheck = false;
            Pineapple = null;
        }

        if (collision.tag == "Window")
        {
            this.GetComponentInParent<Snipe>().aimCheck = true;
            windowBreak = null;
        }
    }
}
