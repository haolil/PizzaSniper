using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WindowBreak : MonoBehaviour
{
    Animator anim;
    public AudioClip breakSound;
    AudioSource audioSource;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void CheckValue()
    {
        Debug.Log("window");
        audioSource.PlayOneShot(breakSound);
        anim.SetBool("Break", true);
        this.enabled = false;
    }
}
