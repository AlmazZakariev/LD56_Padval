using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float turnSpeed = 0;
    public float horizontalInput;
    public float verticalInput;
    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(0, 0, 1);
        horizontalInput = Input.GetAxis(horizontalAxis);
        verticalInput = Input.GetAxis(verticalAxis);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
