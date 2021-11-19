using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracking : MonoBehaviour
{
    public float accuracy = 100;


    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //hit
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //miss
        }

        Debug.Log("");
    }
}
