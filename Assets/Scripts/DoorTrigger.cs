using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public AudioSource LaughSound;
    public bool IsClosed;
    public AudioSource ClosedSound;
    public AudioSource OpenSound;
    public AudioSource CloseSound;

    // Start is called before the first frame update
    void Start()
    {
        
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
            ClosedSound.Play();
            LaughSound.Play();
        }
        else
        {
            OpenSound.Play();
        }
        
        
    }
}
