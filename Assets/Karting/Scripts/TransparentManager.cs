using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentManager : MonoBehaviour
{
    public GameObject[] gObject;
    public GameObject[] gObject2;
    public GameObject[] gObject3;
    //public GameObject transparency;

    public float alpha;


    // Start is called before the first frame update
    void Start()
    {

        //transparency = gameObject;
        /**
        colliders = gameObject.GetComponents<Collider>();
        List<Collider> colliderList = new List<Collider>();
        colliderList.AddRange(gameObject.GetComponents<Collider>());
        **/
    }

    // Update is called once per frame
    void Update()
    {
        //transparency = gameObject.GetComponents<GameObject>();
        //List<GameObject> listTransparency = new List<GameObject>();
        //listTransparency.AddRange(gameObject.GetComponents<GameObject>());

        /**
        ChangeAlpha(transparency.GetComponent<Renderer>().material, alpha);


        foreach (var gObject in gObject)
        {
            ChangeAlpha(gObject.GetComponent<Renderer>().material, alpha);
        }

        **/

        if (alpha > 1)
        {
            alpha = 1;
        }
        else if ( alpha < 0)
        {
            alpha = 0;
        }
    }

    void ChangeAlpha(Material mat, float alphaVal)
    {
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_BaseColor", newColor);
    }
    private void OnTriggerEnter(Collider other)
    {
        //List Object 1

        if (other.CompareTag("EnableTransparent"))
        {
            alpha = 0.1f;
            foreach (var gObject in gObject)
            {
                ChangeAlpha(gObject.GetComponent<Renderer>().material, alpha);
            }
        }
        else if(other.CompareTag("DisableTransparent"))
        {
            alpha = 1f;
            foreach (var gObject in gObject)
            {
                ChangeAlpha(gObject.GetComponent<Renderer>().material, alpha);
            }
            foreach (var gObject2 in gObject2)
            {
                ChangeAlpha(gObject2.GetComponent<Renderer>().material, alpha);
            }
            foreach (var gObject3 in gObject3)
            {
                ChangeAlpha(gObject3.GetComponent<Renderer>().material, alpha);
            }
        }


        // List Object 2


        if (other.CompareTag("EnableTransparent2"))
        {
            alpha = 0.1f;
            foreach (var gObject2 in gObject2)
            {
                ChangeAlpha(gObject2.GetComponent<Renderer>().material, alpha);
            }
        }


        // List Object 3

        if (other.CompareTag("EnableTransparent3"))
        {
            alpha = 0.1f;
            foreach (var gObject3 in gObject3)
            {
                ChangeAlpha(gObject3.GetComponent<Renderer>().material, alpha);
            }
        }



        /**
        alpha = 0.2f;

        ChangeAlpha(transparency.GetComponent<Renderer>().material, alpha);


        foreach (var gObject in gObject)
        {
           
            ChangeAlpha(gObject.GetComponent<Renderer>().material, alpha);
        }
        **/
    }

    /**
    private void OnTriggerExit(Collider other)
    {

        alpha = 1f;

        ChangeAlpha(transparency.GetComponent<Renderer>().material, alpha);


        foreach (var gObject in gObject)
        {

            ChangeAlpha(gObject.GetComponent<Renderer>().material, alpha);
        }
    }
        **/

}
