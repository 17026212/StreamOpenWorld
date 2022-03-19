using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



[SerializeField]

class ChunkData
{
    public Mesh serializableMesh;
    public Material serializableMaterial;
}

public class SaveNLoad : MonoBehaviour
{
    // Start is called before the first frame update

    MeshFilter mesh;
    Material material;
    ChunkData chunkData;

    // public GameObject meshGenerator;
    public GameObject testObject;
    string json;
    string dataPath;
    string finalFilePath;
    private bool loaded;


    private void Update()
    {
        //Test();
    }


    public void SetMesh(Mesh setMesh, Material setMat, GameObject tileMesh)
    {
        if (this.GetComponent<MeshFilter>() == null)
        {
            tileMesh.gameObject.AddComponent<MeshFilter>();
            tileMesh.gameObject.AddComponent<MeshRenderer>();
            tileMesh.gameObject.AddComponent<MeshCollider>();

            tileMesh.GetComponent<MeshFilter>().sharedMesh = setMesh;
            tileMesh.GetComponent<MeshRenderer>().material = setMat;
            tileMesh.GetComponent<MeshCollider>().sharedMesh = setMesh;
            print("Set mesh on loaded terrain");
        }

       // mesh = setMesh;
        material = setMat;
    }

    //public Mesh GetMesh()
    //{
    //   // return mesh;
    //}

    public void ClearMesh()
    {
        Destroy(this.GetComponent<MeshFilter>());
        Destroy(this.GetComponent<MeshRenderer>());
        Destroy(this.GetComponent<MeshCollider>());
    }

    public void Save(string name, GameObject tileMesh)
    {
        if (tileMesh != null)
        {
            chunkData = new ChunkData();
            //mesh = new MeshFilter();

            //mesh.sharedMesh = tileMesh.GetComponent<MeshFilter>().sharedMesh;
            chunkData.serializableMesh = tileMesh.GetComponent<MeshFilter>().sharedMesh;
            // chunkData.serializableMesh = tileMesh.GetComponent<MeshFilter>().sharedMesh = mesh.sharedMesh;

            chunkData.serializableMaterial = tileMesh.GetComponent<Renderer>().material;
          
            //mesh = new Mesh();
            //mesh = tileMesh.gameObject.GetComponent<MeshFilter>();


            json = JsonUtility.ToJson(chunkData, true);
            dataPath = Application.persistentDataPath + "/" + name + ".json";
            //tileMesh.fileName = dataPath;
            print("File name is :" + dataPath);

            File.WriteAllText(dataPath, json);
        }
        else
        {
            print("Gameobject is equal to null");
        }

    }
    public void Load(string filePath, GameObject tileMesh)
    {
        if (filePath != null)
        {
            finalFilePath = Application.persistentDataPath + "/" + filePath + ".json";

            json = File.ReadAllText(finalFilePath);

            ChunkData loadedChunkData = JsonUtility.FromJson<ChunkData>(json);

            SetMesh(loadedChunkData.serializableMesh, loadedChunkData.serializableMaterial, tileMesh);
            //print(finalFilePath);
            Debug.Log("Loaded" + finalFilePath);


        }
    }


    public void Test()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            chunkData = new ChunkData();
            //chunkData.serializableMesh = mesh;
            //chunkData.serializableMaterial = material;
            //mesh  = testObject.gameObject.GetComponent<MeshFilter>();
   
            testObject.gameObject.GetComponent<MeshFilter>().sharedMesh = mesh.sharedMesh;

            json = JsonUtility.ToJson(chunkData, true);
            dataPath = Application.persistentDataPath + "/" + name + ".json";
            File.WriteAllText(dataPath, json);

        }

    }
}

