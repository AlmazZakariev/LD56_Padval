using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource start;
    public AudioSource end;
    
    public void ChangeSound()
    {
        //start.Stop();
        //start.loop = false;

        end.loop = true;
        end.Play();
    }
}
