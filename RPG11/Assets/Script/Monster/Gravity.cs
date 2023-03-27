using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Gravity : MonoBehaviour
{

    public static float globalGravity = -9.81f;

    Rigidbody m_rb;

    void OnEnable()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 gravity = globalGravity * Vector3.down;
        m_rb.AddForce(gravity, ForceMode.Acceleration);
    }
}
