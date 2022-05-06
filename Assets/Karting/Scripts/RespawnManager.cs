using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> targets;
    public List<Quaternion> rotateLocation;
    public bool hasCooldown;
    public int respawnCooldown = 3;
    //public GameObject players;
    [SerializeField] private Transform player;


    public Vector3 rotate;

    public Vector3 position;
    //public float rotateX;
    //public float rotateY;
    //public float rotateZ;
    //[SerializeField] private Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) && hasCooldown == false)
        {
            for (int index = 0; index < targets.Count - 1; index++)
            {
                player.transform.position = targets[index].transform.position;
                //player.transform.rotation = rotateLocation[index];
                player.transform.position = position;
                player.transform.Rotate(rotate);

                Physics.SyncTransforms();
                hasCooldown = true;
                StartCoroutine(RespawnCooldown());
            }
        }
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
            rotate = player.transform.eulerAngles;
            position = player.transform.position;
            targets.Add(other.gameObject);
            if (targets.Count > 5)
            {
                targets.RemoveAt(0);
                //rotateLocation.RemoveAt(0);
            }
            //rotateLocation = player.gameObject.transform.rotation;
        }
        if (other.CompareTag("Respawn"))
        {
            for (int index = 0; index < targets.Count - 1; index++)
            {
                player.transform.position = targets[index].transform.position;
                //player.transform.rotation = rotateLocation[index].SetEulerRotation(1,2,3);
                player.transform.position = position;
                player.transform.Rotate(rotate);
                Physics.SyncTransforms();
            }
            
        }
    }
}
