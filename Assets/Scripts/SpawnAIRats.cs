using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAIRats : MonoBehaviour
{
    private bool triggerUsed = false;
    public bool right = true;
    public GameObject SpawnPoint;
    public GameObject Enemy;
    public bool Start = false;

    // Update is called once per frame
    void Update()
    {
        if (Start)
        {
            Start = false;
            StartRandomInvoke();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && !triggerUsed)
        {
            triggerUsed = true;
            

        }
    }

    void StartRandomInvoke()
    {  
        float randomTime = Random.Range(2f, 5f);
        InvokeRepeating("MyFunction", randomTime, randomTime);
    }

    void MyFunction()
    {
        Instantiate(Enemy, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
    }
}
