using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineappleAI : MonoBehaviour
{
    [SerializeField] float walkDistance = 3f;
    [SerializeField] bool startLeft = true;

    int currentState = 0; //0=idle, 1=run, 2=death
    int idleWalkState = 0; //0=left, 1=right, 2=stop
    int lastWalkState = 0;
    float idleSpeed = 1.0f;
    float runSpeed = 2.5f;

    bool walkStateActive = false;

    private void Start()
    {
        if (startLeft)
        {
            idleWalkState = 0;
        }
        else
        {
            idleWalkState = 1;
        }
        idleSpeed = idleSpeed * Random.Range(1.0f,1.2f);
    }
    void Update()
    {
        switch (currentState)
        {
            case 0: //idle
                WalkIdle();
                break;
            case 1: //run
                break;
            case 2: //death
                break;
            default:
                Debug.LogWarning("AI Current State Fail");
                break;
        }
    }
    void WalkIdle()
    {
        if(walkStateActive == false)
        {
            walkStateActive = true;
            if(idleWalkState == 0 || idleWalkState == 1)
            {
                StartCoroutine("WalkState", walkDistance);
            }
            else
            {
                StartCoroutine("WalkState", Random.Range(2,4));
            }
        }
        else
        {
            switch (idleWalkState)
            {
                case 0: //left
                    transform.position += Vector3.left * idleSpeed * Time.deltaTime;
                    break;
                case 1: //right
                    transform.position += Vector3.right * idleSpeed * Time.deltaTime;
                    break;
                case 2: //stop
                    break;
                default:
                    Debug.LogWarning("AI Walk State Fail");
                    break;
            }
        }
    }
    IEnumerator WalkState(float time)
    {
        yield return new WaitForSeconds(time);
        switch (idleWalkState)
        {
            case 0: //left
                idleWalkState = 2;
                lastWalkState = 0;
                break;
            case 1: //right
                idleWalkState = 2;
                lastWalkState = 1;
                break;
            case 2: //stop
                if (lastWalkState == 0)
                {
                    idleWalkState = 1;
                }
                else if (lastWalkState == 1)
                {
                    idleWalkState = 0;
                }
                lastWalkState = 2;
                break;
            default:
                Debug.LogWarning("AI Walk State Fail");
                break;
        }
        walkStateActive = false;
    }
}