using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RLMauseController: MonoBehaviour
{
    public float speed = 40.0f;
    public bool right = true;
    // Start is called before the first frame update
    void Start()
    {
        if (!right)
        {
            speed *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    { 
  
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
