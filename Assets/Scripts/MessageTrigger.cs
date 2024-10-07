using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageTrigger : MonoBehaviour
{

    private bool triggerUsed = false;
    public bool right = true;
    public GameObject SpawnPoint;
    public GameObject Enemy;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")&& !triggerUsed)
        {
            triggerUsed = true;
            Instantiate(Enemy, SpawnPoint.transform.position, SpawnPoint.transform.rotation);

        }
    }
}
