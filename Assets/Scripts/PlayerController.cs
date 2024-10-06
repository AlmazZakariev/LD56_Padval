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
    public Transform _transform;
    public GameObject Player;

    private void Start()
    {
        SetRotationOffset();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
       
        horizontalInput = Input.GetAxis(horizontalAxis);
        verticalInput = Input.GetAxis(verticalAxis);
        Player.transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);


        float mouseX = Input.GetAxis("Mouse X") * mouseSensetive * Time.deltaTime; //вверх вниз
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetive * Time.deltaTime;//влево вправо

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        Player.transform.Rotate(Vector3.up*mouseX);
    }

    private void SetRotationOffset()
    {   
        _transform = transform;
    }
}
