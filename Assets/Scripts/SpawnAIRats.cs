using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAIRats : MonoBehaviour
{

    public GameObject[] Enemy;
    public bool Start = false;

    // Update is called once per frame
    void Update()
    {
        if (Start)
        {
            Start = false;
            StartRandomSpawn();
        }
    }

    void StartRandomSpawn()
    {  
        float randomTime = Random.Range(2f, 5f);
        InvokeRepeating("Spawn", randomTime, randomTime);
    }

    void Spawn()
    {
        var id = Random.Range(0, Enemy.Length);
        Instantiate(Enemy[id], transform.position, transform.rotation);
    }
}
