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
    public GameObject flashLight;
    public GameObject light;
    public AudioSource lightAudio;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!flashLight.active)
            {
                return;
            }
            if (lightAudio.isPlaying)
            {
                return;
            }

            lightAudio.Play();
            light.SetActive(!light.active);
        }
    }


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
        
        //Фикс кручения
        _rb.angularVelocity = Vector3.zero;
    }

    private void RotationLogic()
    {
        mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.fixedDeltaTime; // влево-вправо
        mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.fixedDeltaTime; // вверх-вниз

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f);
        goCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

        transform.Rotate(Vector3.up * mouseX);
    }

}
