using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
   // public GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(0, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
