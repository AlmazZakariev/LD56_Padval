using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashLights : MonoBehaviour
{
    public GameObject FlashLightOnPlayer;

    // Start is called before the first frame update
    void Start()
    {
        FlashLightOnPlayer.SetActive(false);
    }


    private void OnTriggerStay(Collider collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return; 
        }
        if (!Input.GetKey(KeyCode.F))
        {
            return;
        }

        gameObject.SetActive(false);

        FlashLightOnPlayer.SetActive(true);
    }

}
