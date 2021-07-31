using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FireBall : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    public void Throw(Vector3 fireDireciton)
    {
        rb.AddForce(fireDireciton * 1000);
    }
}
