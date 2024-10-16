using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
 
    public float horizontalInput;
    public float verticalInput;
    private string horizontalAxis = "Horizontal";
    private string verticalAxis = "Vertical";

    public float mouseSensetive = 100f;
    private float xRotation;
    public GameObject Player;
 

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       
        horizontalInput = Input.GetAxis(horizontalAxis);
        verticalInput = Input.GetAxis(verticalAxis);
        Player.transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
     
        Player.transform.Translate(Vector3.left * Time.deltaTime * speed * horizontalInput*-1);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensetive * Time.deltaTime; //����� ����
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetive * Time.deltaTime;//����� ������

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -20f, 30f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        Player.transform.Rotate(Vector3.up*mouseX);
    }

}
