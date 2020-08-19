using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoobTether : MonoBehaviour
{
    [SerializeField] private GameObject boob;
    private Rigidbody boobRB;
    [SerializeField] float tetherLength = 0.25f;
    private bool once = false;
    private float distance
    {
        get
        {
            return (boob.transform.position - transform.position).magnitude;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        boobRB = boob.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (distance > tetherLength && !once)
        {
            boobRB.velocity += (-(transform.position - boob.transform.position).normalized * Vector3.Dot(boobRB.velocity, transform.position - boob.transform.position)) * 2;
            Vector3 displacement = (transform.position - boob.transform.position) - (transform.position - boob.transform.position).normalized * tetherLength;
            boobRB.velocity -= displacement * 2;
            boob.transform.position += (transform.position - boob.transform.position) * Mathf.Abs(tetherLength - distance);
            //once = true;
        }
    }
}
