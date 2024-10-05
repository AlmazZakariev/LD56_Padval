using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    //Vector3 offset = new Vector3(0, 4, -7);
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        SetOffet();
    }

    // Update is called once per frame


    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        //if (tag == "FirstViewCamera")
        {
            transform.rotation = player.transform.rotation;
        }
    }
    void SetOffet()
    {
        offset = transform.position;
    }
}
