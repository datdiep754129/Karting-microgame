using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    public float gravityScale = 1f;
    public GameObject gravityTarget;

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
        Vector3 gravity = globalGravity * gravityScale * Vector3.up;
        m_rb.AddForce(gravity, ForceMode.Acceleration);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GravityReverse_Up"))
        {
            gravityScale = 2;
            gravityTarget.transform.Rotate(0, 0, 0);

        }
        if (other.CompareTag("GravityReverse_Down"))
        {
            gravityScale = -2;
            gravityTarget.transform.Rotate(0, 0, 180);
        }
    }
}
