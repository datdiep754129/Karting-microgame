using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> targets;
    //public List<Quaternion> rotateLocation;
    public bool hasCooldown;
    public int respawnCooldown = 3;
    //public GameObject players;
    [SerializeField] private Transform player;
    //[SerializeField] private Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void fixedUpdate()
    {
    }
    IEnumerator RespawnCooldown()
    {
        yield return new WaitForSeconds(respawnCooldown);
        hasCooldown = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "savepoint")
        {
            targets.Add(other.gameObject);
           // rotateLocation.Add(other.transform.rotation);
            Debug.Log(other.gameObject);
            //rotateLocation = player.gameObject.transform.rotation;
        }
        if (other.CompareTag("Respawn"))
        {
            for(int index = 0; index < targets.Count-1; index++)
            {
                player.transform.position = targets[index].transform.position;
               // player.transform.rotation = rotateLocation[index];
                Physics.SyncTransforms();

            }
        }
        /**       
        if (Input.GetKeyDown(KeyCode.R) && hasCooldown == false)
        {
            for (int index = 0; index < targets.Count - 1; index++)
            {
                player.transform.position = targets[index].transform.position;
                player.transform.rotation = rotateLocation[index];
                Physics.SyncTransforms();
                hasCooldown = true;
                StartCoroutine(RespawnCooldown());
            }
        }
        **/
    }
}
