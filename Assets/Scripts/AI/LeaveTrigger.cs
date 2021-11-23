using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTrigger : MonoBehaviour
{
    AIManager aIManager;
    private void Start()
    {
        aIManager = GetComponentInParent<AIManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            aIManager.Escaped();
        }
    }
}
