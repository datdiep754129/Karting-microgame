using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleportTarget;
    public List<Transform> teleportPosition;
    public bool hasCooldown;
    public int respawnCooldown = 3;
    public int index = 0;
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
        if (other.CompareTag("Teleport_A") && hasCooldown == false)
        {
            while (index < teleportPosition.Count)
            {
                hasCooldown = true;
                StartCoroutine(RespawnCooldown());
                teleportTarget.transform.position = teleportPosition[index].transform.position;
                index++;
                return;
            }
        }

    }
}
