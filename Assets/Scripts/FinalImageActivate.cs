using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalImageActivate : MonoBehaviour
{
    public GameObject FinalScreen;
    // Start is called before the first frame update
    public void ActivateFinalScreen()
    {
        FinalScreen.SetActive(true);
    }
    public void StopTheGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
