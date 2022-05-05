using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentManager : MonoBehaviour
{
    public Collider[] ListCollider;
    public GameObject transparency;
    public float alpha = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //ChangeAlpha(transparency.GetComponent<Renderer>().material, alpha);
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);
    }
    /** 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnableTransparent"))
        {
            alpha = 0.2f;
            ChangeAlpha(transparency.GetComponent<Renderer>().material, alpha);
        }
        else if(other.CompareTag("DisableTransparent"))
        {
            alpha = 1f;
            ChangeAlpha(transparency.GetComponent<Renderer>().material, alpha);
        }
    }
    **/
}
