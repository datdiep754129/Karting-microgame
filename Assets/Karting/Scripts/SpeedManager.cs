using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public GameObject player;

    private bool hasCooldown;
    public float boostCooldown = 5f;
    public float boostDuration = 1f;
    private float speedBoost = 3;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasCooldown)
        {

        }
    }


}
