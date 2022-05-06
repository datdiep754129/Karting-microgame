using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleportTarget;
    public Transform teleportPosition;
    public bool hasCooldown;
    public int respawnCooldown = 3;

    public Vector3 positionPlayer;
    public Vector3 positionA;
    public Vector3 positionB;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void FixedUpdate()
    {
    }

    IEnumerator RespawnCooldown()
    {
        yield return new WaitForSeconds(respawnCooldown);
        hasCooldown = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            teleportTarget.transform.position = teleportPosition.transform.position;
            hasCooldown = true;
            StartCoroutine(RespawnCooldown());
        }
        
    }
}
