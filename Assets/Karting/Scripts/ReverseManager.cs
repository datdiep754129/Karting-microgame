using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseManager : MonoBehaviour
{
    public GameObject reverseTarget;
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
        if (other.CompareTag("GravityReverse_Up") && hasCooldown == false)
        {
            reverseTarget.transform.Rotate(0, 0, 180);
        }
        else if (other.CompareTag("GravityReverse_Down") && hasCooldown == false)
            {
                reverseTarget.transform.Rotate(0, 0, 0);
            }

    }
}
