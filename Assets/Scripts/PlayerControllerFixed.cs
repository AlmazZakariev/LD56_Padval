using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//эта строчка гарантирует что наш скрипт не завалится 
//ести на плеере будет отсутствовать компонент Rigidbody
[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerFixed : MonoBehaviour
{
    public float Speed = 10f;
    public float MouseSensitivity = 100f;

    //что бы эта переменная работала добавьте тэг "Ground" на вашу поверхность земли
    private bool _isGrounded;
    private Rigidbody _rb;

    public Transform goCamera;
    public float mouseX;
    public float mouseY;
    private float xRotation;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // обратите внимание что все действия с физикой 
    // необходимо обрабатывать в FixedUpdate, а не в Update
    void FixedUpdate()

    { 
        RotationLogic();
        MovementLogic();
  
    }
    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Получаем направление взгляда камеры
        Vector3 cameraForward = goCamera.forward;
        Vector3 cameraRight = goCamera.right;

        // Нормализуем направления, чтобы игнорировать вертикальную составляющую
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Вычисляем вектор движения относительно направления взгляда камеры
        Vector3 movement = (cameraForward * moveVertical + cameraRight * moveHorizontal).normalized;

        // Перемещаем игрока
        _rb.MovePosition(transform.position + movement * Speed* Time.fixedDeltaTime);
    }

    private void RotationLogic()
    {
        mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.fixedDeltaTime; // влево-вправо
        mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.fixedDeltaTime; // вверх-вниз

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -20f, 30f);
        goCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }


    //private void MovementLogic()
    //{
    //    float moveHorizontal = Input.GetAxis("Horizontal");
    //    float moveVertical = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    //    // Перемещаем игрока
    //    _rb.MovePosition(transform.position + movement * Speed * Time.fixedDeltaTime);

    //    // Вращаем игрока в направлении движения
    //    if (movement != Vector3.zero)
    //    {
    //        Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
    //        _rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime));
    //    }
    //}

    //private void RotationLogic()
    //{
    //    float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.fixedDeltaTime; // влево-вправо
    //    float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.fixedDeltaTime; // вверх-вниз

    //    xRotation -= mouseY;
    //    xRotation = Mathf.Clamp(xRotation, -20f, 30f);
    //    goCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

    //    transform.Rotate(Vector3.up * mouseX);
    //}

}
