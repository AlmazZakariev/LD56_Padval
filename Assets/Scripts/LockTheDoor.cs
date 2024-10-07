using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockTheDoor : MonoBehaviour
{
    public Animator DoorAnimator;
    public AudioSource CloseDoor;
    public DoorTrigger DoorTriggerScript;
    private bool triggered = false;
    private GameManager managerScript;

    private void Start()
    {
        GameObject manager = GameObject.Find("gamemanager");

        if (manager != null)
        {

            managerScript = manager.GetComponent<GameManager>();
        }
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

        if (managerScript != null)
        {
            managerScript.ChangeSound();
        }
       

    }
}
