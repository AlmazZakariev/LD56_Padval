using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTheDoor : MonoBehaviour
{
    public Animator DoorAnimator;
    public AudioSource CloseDoor;
    public DoorTrigger DoorTriggerScript;
    private bool triggered = false;

    private void Start()
    {
        
    }

    private void OnTriggerStay(Collider collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        
        if (triggered)
        {
            return;
        }

        triggered = true;

        DoorAnimator.SetTrigger("Close");
        CloseDoor.Play();
        DoorTriggerScript.CanBeOpened = false;
        DoorTriggerScript.IsClosed = true;

    }
}
