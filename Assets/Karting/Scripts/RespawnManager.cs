using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> targets;
    //public GameObject players;
    [SerializeField] private Transform player;
    //[SerializeField] private Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameObject jump = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "savepoint")
        {
            targets.Add(other.gameObject);
        }
        if (other.CompareTag("Respawn"))
        {
            for(int index = 0; index < targets.Count-1; index++)
            {
                player.transform.position = targets[index].transform.position;
                Physics.SyncTransforms();
            }
        }
    }
}
