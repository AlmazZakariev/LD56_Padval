using InternalRealtimeCSG;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAI : MonoBehaviour
{
    private Transform player;
    private Rigidbody rb;
    private GameManager managerScript;

    public Animator animator;
    public AudioSource audioRunning;

    private System.Random random;
    private float minDistance = 2f;
    private bool isRunning;
    private bool waiting = false;
    private float waitingDist;
    private bool ending = false;

    public float moveSpeed = 3f;
    public float followingDistMin = 4;
    public float followingDistMax = 6;
    
    public float animationOffsetMin = 0f;
    public float animationOffsetMax = 1f;

    public float waitingDistMin = 1;
    public float waitingDistMax = 2;

    public float distDownScaleDelta = 0.01f;

    void Start()
    {
        var UID = Convert.ToInt32(DateTime.UtcNow.Ticks % 1000000000);
        random = new System.Random(UID);

        rb = GetComponent<Rigidbody>();

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        GameObject manager = GameObject.Find("gamemanager");
        if (manager != null)
        {
            managerScript = manager.GetComponent<GameManager>();
        }

        minDistance = (float)(followingDistMin + (followingDistMax-followingDistMin) * random.NextDouble());
        waitingDist = (float)(waitingDistMin + (waitingDistMax - waitingDistMin) * random.NextDouble());
    }

    void FixedUpdate()
    {
        if (player == null)
        {
            return;
        }

        if (!ending)
        {
            ending = managerScript.needReduceDist;
        }
        else if (ending)
        {
            minDistance -= distDownScaleDelta;
        }

        Vector3 direction = player.position - transform.position;
        direction.Normalize();

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        var currentIsRunning = distanceToPlayer > minDistance;
        if (waiting && currentIsRunning)
        {
            currentIsRunning = distanceToPlayer > minDistance+ waitingDist;
        }

        //animation
        if (currentIsRunning != isRunning)
        {     
            ChangeAnimation(currentIsRunning);

            waiting = !currentIsRunning;
        }

        isRunning = currentIsRunning;

        //moving
        if (isRunning)
        {
            Vector3 targetPosition = transform.position + direction * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(targetPosition);
        }

        //rotation
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);

        //audio
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
    private void ChangeAnimation(bool running)
    {
        if (!running)
        {
            //var offset = Random.Range(minTime, maxTime);
            Invoke("IdleAnimWithOffset", GetRandomTime2());
        }
        else
        {
            animator.SetBool("isRunning", running);
        }

    }
    private void IdleAnimWithOffset()
    {

        animator.SetBool("isRunning", isRunning);
    }

    public float GetRandomTime2()
    {
        var result = (float)(animationOffsetMin+(animationOffsetMax-animationOffsetMin)*random.NextDouble());
        Debug.Log("Случайное время: " + result);
        return result;

    }
}