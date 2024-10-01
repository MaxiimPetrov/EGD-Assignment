using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class moving_platform : MonoBehaviour
{
    public float speed;
    public float switchTime = 2f;

    private Rigidbody rb;
    private float timer;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        timer = switchTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            speed *= -1;
            timer = switchTime;
        }
    }

    private void FixedUpdate()
    {
        Vector3 new_position = rb.position;
        new_position.x += speed * Time.fixedDeltaTime;
        rb.position = new_position;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

}
