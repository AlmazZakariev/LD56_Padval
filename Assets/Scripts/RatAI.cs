using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 3f; 
    public float minDistance = 2f;

    private Rigidbody rb;
    private Animator animator;
    public bool isRunning;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        animator.SetBool("isRunning", distanceToPlayer > minDistance);
        //animator.SetBool("isRunning", true);

        isRunning = distanceToPlayer > minDistance;


        if (distanceToPlayer > minDistance)
        {
            Vector3 targetPosition = transform.position + direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
        }
    }
}