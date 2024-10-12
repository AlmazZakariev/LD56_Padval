using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public AudioSource LaughSound;
    public bool IsClosed;
    public AudioSource OpenSound;
    public bool CanBeOpened = true;
    //public GameObject DoorColldier;

    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        if (!Input.GetKey(KeyCode.F))
        {
            return;
        }

        if (LaughSound.isPlaying)
        {
            return;
        }

        if (IsClosed)
        {
            if (CanBeOpened)
            {
                OpenSound.Play();
                if (Animator != null)
                {
                    Animator.SetTrigger("Open");
                }
                IsClosed = false;
                CanBeOpened = false;
                //DoorColldier.SetActive(false);
            }
            else
            {
                LaughSound.Play();
            } 
        }
    }
}
