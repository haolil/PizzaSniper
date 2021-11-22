using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PineappleAI : MonoBehaviour
{
    [SerializeField] float walkDistance = 3f;
    [SerializeField] bool startLeft = true;
    bool alive = true;
    Snipe snipe;
    TargetCheck targetCheck;
    AIManager aiManager;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    int currentState = 0; //0=idle, 1=run,
    int idleWalkState = 0; //0=left, 1=right, 2=stop
    int lastWalkState = 0;
    float idleSpeed = 1.0f;
    float runSpeed = 3f;
    Vector2 velocity;
    bool stateSwitched = false;
    bool runToLeft = false;
    bool walkStateActive = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        snipe = FindObjectOfType<Snipe>();
        targetCheck = FindObjectOfType<TargetCheck>();
        aiManager = GetComponentInParent<AIManager>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (startLeft)
        {
            idleWalkState = 0;
            animator.Play("Run");
            spriteRenderer.flipX = false;
        }
        else
        {
            idleWalkState = 1;
            animator.Play("Run");
            spriteRenderer.flipX = true;
        }
        idleSpeed = idleSpeed * Random.Range(1.0f,1.2f);
    }
    public void PineappleHit()
    {
        aiManager.TotalDead++;
        gameObject.tag = "Untagged";
        alive = false;
        rb.velocity = Vector3.zero;
        animator.Play("Explode");
        Destroy(gameObject, 0.375f); // This is temporary, should have death animation later
    }
    void FixedUpdate()
    {
        if (alive)
        {
            if (snipe && snipe.hitCount > 0 && stateSwitched == false && currentState != 1)
            {
                currentState = 1; // set state to run if a pineapple was killed
                stateSwitched = true;
            }
            switch (currentState)
            {
                case 0: //idle
                    WalkIdle();
                    break;
                case 1: //run
                    RunForLife();
                    break;
                default:
                    Debug.LogWarning("AI Current State Fail");
                    break;
            }
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
                    velocity.x = Mathf.Lerp(velocity.x, Vector3.left.x * idleSpeed, Time.deltaTime * 6f);
                    break;
                case 1: //right
                    velocity.x = Mathf.Lerp(velocity.x, Vector3.right.x * idleSpeed, Time.deltaTime * 6f);
                    break;
                case 2: //stop
                    velocity.x = Mathf.Lerp(velocity.x, Vector3.zero.x * idleSpeed, Time.deltaTime * 15f);
                    break;
                default:
                    Debug.LogWarning("AI Walk State Fail");
                    break;
            }
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }
    IEnumerator WalkState(float time)
    {
        switch (idleWalkState)
        {
            case 0: //left
                animator.Play("Run");
                spriteRenderer.flipX = false;
                break;
            case 1: //right
                animator.Play("Run");
                spriteRenderer.flipX = true;
                break;
            case 2: //stop
                animator.Play("Idle");
                break;
        }
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
    void RunForLife()
    {
        if(stateSwitched == true)
        {
            StopCoroutine("WalkState");
            if (transform.position.x >= 0)
            {
                runToLeft = true;
                animator.Play("Panic");
                spriteRenderer.flipX = false;
            }
            else
            {
                runToLeft = false;
                animator.Play("Panic");
                spriteRenderer.flipX = true;
            }
            stateSwitched = false;
        }
        if(runToLeft == true)
        {
            velocity.x = Mathf.Lerp(velocity.x, Vector3.left.x * runSpeed, Time.deltaTime * 8f);
        }
        else
        {
            velocity.x = Mathf.Lerp(velocity.x, Vector3.right.x * runSpeed, Time.deltaTime * 8f);
        }
        rb.MovePosition(rb.position + velocity * Time.deltaTime);
    }
}