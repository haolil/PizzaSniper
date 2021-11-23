using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCheck : MonoBehaviour
{
    public PineappleAI Pineapple;
    public WindowBreak windowBreak;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if(hit.collider != null && hit.collider.tag == "Enemy" || hit.collider.tag == "Window")
            {
                this.GetComponentInParent<Snipe>().aimCheck = true;
                if(hit.collider.tag == "Enemy")
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
}
