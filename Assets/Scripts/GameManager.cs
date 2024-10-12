using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool needReduceDist = false;
    public AudioSource end;
    public GameObject UI;

    private bool ended = false;

    public int maxEnemy;
    public int enemiesToReduceDist = 20;
    public int Enemies;
    public float endUITime = 7f;

    public void Update()
    {
        if (ended)
        {
            return;
        }

        var enemiesCount = (CountObjectsWithTag("Enemy"));

        if (enemiesCount >= maxEnemy)
        {
            ended = true;
            UI.SetActive(true);
            Invoke("EndGame", endUITime);
        }
        if (enemiesCount >= enemiesToReduceDist)
        {
            needReduceDist = true;
        }
    }
    public void ChangeSound()
    {
        end.Play();
    }

    public int CountObjectsWithTag(string tag) 
    {    
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);
        Enemies = objectsWithTag.Length;
        return objectsWithTag.Length;
    }

    //public void EndGame()
    //{
    //    Time.timeScale = 0;
    //}
}
