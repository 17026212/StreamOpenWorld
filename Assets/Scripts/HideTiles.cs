using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class HideTiles : MonoBehaviour
{
    [SerializeField]
    private string tileTag;
    [SerializeField]
    private Vector3 tileSize;
    [SerializeField]
    private int maxDistance;
    public GameObject[] tiles;
    //public List<GameObject> chunks = new List<GameObject>();

    static public SaveNLoad saveNLoad;
    // Use this for initialization
    void Start()
    {
        //tiles.Add(GameObject.FindGameObjectsWithTag(tileTag));
        saveNLoad = FindObjectOfType<SaveNLoad>();
        this.tiles = GameObject.FindGameObjectsWithTag(tileTag);
        DeactivateDistantTiles();

    }
    void DeactivateDistantTiles()
    {
        
        Vector3 playerPosition = gameObject.transform.position;
        if (tiles != null)
        {
            foreach (GameObject tile in tiles)
            {
                Vector3 tilePosition = tile.gameObject.transform.position + (tileSize / 2f);
                float xDistance = Mathf.Abs(tilePosition.x - playerPosition.x);
                float zDistance = Mathf.Abs(tilePosition.z - playerPosition.z);
                if (xDistance + zDistance > maxDistance && tile.gameObject.GetComponent<MeshFilter>() == true)
                {

                        // tile.SetActive(false);
                        //tile.
                        //Debug.Log("Deactive!");
                        //saveNLoad.test();
                        saveNLoad.Save(tile.gameObject.name, tile.gameObject);
                        //RemoveElement(ref tiles, 1);
                        Destroy(tile.GetComponent<MeshFilter>());

                        Destroy(tile.GetComponent<MeshRenderer>());
                        Destroy(tile.GetComponent<MeshCollider>());
                    
                }

                
                    if (xDistance + zDistance < maxDistance && tile.gameObject.GetComponent<MeshFilter>() == null)
                    {
                       saveNLoad.Load(tile.gameObject.name, tile);


                    //print("Fuck");
                    }

                else
                {

                }
                
            }
        }
    }
    void Update()
    {
        DeactivateDistantTiles();

    }

    private void RemoveElement<T>(ref T[] arr, int index)
    {
        for(int i = index; i < arr.Length - 1; i++)
        {
            arr[i] = arr[i + 1];
        }

        Array.Resize(ref arr, arr.Length - 1);
    }

    
}