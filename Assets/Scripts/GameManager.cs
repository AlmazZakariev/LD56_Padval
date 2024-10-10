using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxEnemy;
    //public AudioSource start;
    public AudioSource end;
    public int Enemies;
    public GameObject UI;
    private bool ended = false;
    public void Update()
    {
        if (ended)
        {
            return;
        }
        if (CountObjectsWithTag("Enemy") >= maxEnemy)
        {
            ended = true;
            UI.SetActive(true);
            Invoke("EndGame", 3f);
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

    public void EndGame()
    {
        Time.timeScale = 0;
        Application.Quit();
    }
}
