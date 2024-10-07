using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RLMauseController: MonoBehaviour
{
    public float speed = 40.0f;
    public bool right = true;
    private Vector3 previousPosition;
    private Rigidbody _rb;
    public float minR;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
       

        previousPosition = transform.position;
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 moveDirection = gameObject.transform.rotation *Vector3.right * speed * Time.fixedDeltaTime;
        _rb.MovePosition(transform.position + moveDirection);

        if (Vector3.Distance(transform.position, previousPosition) < minR)
        {
            if (count > 5)
            {
                Destroy(gameObject);
            }
            count++;
        }
        previousPosition = transform.position;
    }
}
