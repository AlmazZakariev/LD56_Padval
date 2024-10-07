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
    public AudioSource audioRunning;

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

        isRunning = distanceToPlayer > minDistance;

        animator.SetBool("isRunning", isRunning);
        if (isRunning)
        {
            Vector3 targetPosition = transform.position + direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
        }

        if (!isRunning)
        {
            audioRunning.loop = false;
            audioRunning.Stop();
        }
        else
        {
            if (audioRunning.isPlaying)
            {
                return;
            }
            audioRunning.loop = true;
            audioRunning.Play();
        }
    }
}