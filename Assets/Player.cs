using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private bool jump = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jump)
        {
            rb.velocity += Vector3.up * jumpSpeed;
            jump = false;
        }
    }
}
