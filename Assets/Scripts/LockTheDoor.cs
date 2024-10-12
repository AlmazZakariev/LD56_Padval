using JetBrains.Annotations;
using System;
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
    public SpawnAIRats[] SpawnAIRatsScript;

    private void Start()
    {
        GameObject manager = GameObject.Find("gamemanager");

        if (manager != null)
        {

            managerScript = manager.GetComponent<GameManager>();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (triggered)
        {
            return;
        }

        if (!collision.CompareTag("Player"))
        {
            return;
        }

        triggered = true;

        Invoke("closeDore", 1f);

        managerScript.ChangeSound();

        

        Invoke("startRats", 10f);
    }

    private void startRats()
    {
        foreach (var s in SpawnAIRatsScript)
        {
            s.Start = true;
        }
    }

    private void closeDore()
    {
        DoorAnimator.SetTrigger("Close");
        CloseDoor.Play();
        DoorTriggerScript.CanBeOpened = false;
        DoorTriggerScript.IsClosed = true;
    }
}
