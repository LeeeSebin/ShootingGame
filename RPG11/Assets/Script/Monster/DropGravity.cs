using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class DropGravity : MonoBehaviour
{
    public bool gra = false;
    public static float globalGravity = -18.81f;
    Vector3 gravity;
    Rigidbody m_rb;
    private float boomtime;

    void OnEnable()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gra == false)
        {
            gravity = globalGravity * Vector3.down;
            m_rb.AddForce(gravity, ForceMode.Acceleration);
        }
        else if (gra == true)
        {
            gravity = globalGravity * Vector3.up;
            m_rb.AddForce(gravity, ForceMode.Acceleration);
        }
    }
}
