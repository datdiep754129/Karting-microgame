using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomGravity : MonoBehaviour
{
    public float gravityScale = 1f;
    public GameObject gravityTarget;

    public bool hasCooldown;
    public int respawnCooldown = 3;

    public static float globalGravity = -9.81f;
    Rigidbody m_rb;

    IEnumerator RespawnCooldown()
    {
        yield return new WaitForSeconds(respawnCooldown);
        hasCooldown = false;
    }
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
        if (other.CompareTag("GravityReverse_Up") && hasCooldown == false)
        {
            hasCooldown = true;
            StartCoroutine(RespawnCooldown());
            gravityScale = 1.5f;
            gravityTarget.transform.Rotate(0, 0, 0);

        }
        if (other.CompareTag("GravityReverse_Down") && hasCooldown == false)
        {
            hasCooldown = true;
            StartCoroutine(RespawnCooldown());
            gravityScale = -1.5f;
            gravityTarget.transform.Rotate(0, 0, 180);
        }
    }
}
