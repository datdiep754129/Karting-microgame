using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleportTarget;
    public List<Transform> teleportPositionA;
    public List<Transform> teleportPositionB;
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
            while (index < teleportPositionA.Count)
            {
                hasCooldown = true;
                StartCoroutine(RespawnCooldown());
                teleportTarget.transform.position = teleportPositionA[index].transform.position;
                index++;
                return;
            }
            if(index == teleportPositionA.Count)
            {
                index =0;
            }
        }
        if(other.CompareTag("Teleport_B") && hasCooldown == false)
        {
            if(index == 0)
            {
                index = teleportPositionB.Count;
            }
            else
            {
                while (index <= teleportPositionB.Count)
                {
                    hasCooldown = true;
                    StartCoroutine(RespawnCooldown());
                    index--;
                    teleportTarget.transform.position = teleportPositionB[index].transform.position;
                    return;
                }
            }
        }

    }
}
