using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRespawn : MonoBehaviour
{
    public List<GameObject> targets;
    //public GameObject players;
    [SerializeField] private Transform player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "savepoint")
        {
            targets.Add(other.gameObject);
            //rotateLocation = player.gameObject.transform.rotation;
        }
        if (other.CompareTag("Respawn"))
        {
            for (int index = 0; index < targets.Count - 1; index++)
            {
                player.transform.position = targets[index].transform.position;
                Physics.SyncTransforms();

            }
        }
    }
}
