using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleportTarget;
    public List<Transform> teleportPosition;
    public bool hasCooldown;
    public int respawnCooldown = 3;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame

    IEnumerator RespawnCooldown()
    {
        yield return new WaitForSeconds(respawnCooldown);
        hasCooldown = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        int index;
        for(index = 0; index < teleportPosition.Count; index++)
        {
            if (other.CompareTag("Teleport_A") && hasCooldown == false)
            {
                teleportTarget.transform.position = teleportPosition[index].transform.position;
                hasCooldown = true;
                StartCoroutine(RespawnCooldown());
            }

        }
        
    }
}
