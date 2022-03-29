using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{

    private GameObject triggeringNpc;
    private bool triggering;

    public GameObject npcText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(triggering)
        {
            npcText.SetActive(true);

            if(Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Accepted quest");
            }
        }

        else
        {
            npcText.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            triggering = true;
            triggeringNpc = other.gameObject;
            Debug.Log("Hello Player");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "NPC")
        {
            triggering = true;
            triggeringNpc = null;
            Debug.Log("Goodbye Player");
        }
    }
}
