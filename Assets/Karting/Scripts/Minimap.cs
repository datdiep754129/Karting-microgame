using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public GameObject player;
    public Transform playerRotation;
    private Vector3 offset;
    private Vector3 newTrans;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerPosition = player.transform.position;
        playerPosition.y = player.transform.position.y + 20;
        //playerPosition.y = transform.position.y;
        transform.position = playerPosition;

        

        transform.rotation = Quaternion.Euler(90f, playerRotation.eulerAngles.y, 0f);

    }
}
