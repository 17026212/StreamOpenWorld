using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;



public class MeshDumper : MonoBehaviour
{

    public Mesh myMesh;
    public Mesh test;
    public GameObject targetObject;
    string m_Path;

    [SerializeField] private Shader shader;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            MeshDump();
            //Destroy(gameObject.GetComponent<MeshFilter>());

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            MeshUndump();
           // gameObject.AddComponent<MeshFilter>().mesh = myMesh;
        }

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    Destroy(gameObject.GetComponent<MeshFilter>());
        //}

        //if (Input.GetKeyDown(KeyCode.Y))
        //{

        //    gameObject.AddComponent<MeshFilter>().mesh = myMesh;
        //}
    }
    void Start()
    {
        myMesh = targetObject.GetComponent<MeshFilter>().mesh;

        Update();
    }

    /// Creates a binary dump of a mesh
    /// </summary>
    public void MeshDump()
    {
        //gameObject.GetComponent<MeshFilter>().mesh = myMesh;
        //GetComponent<MeshFilter>().mesh = myMesh;
      
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        System.IO.FileStream fs = new System.IO.FileStream(Application.dataPath + "meshFile.dat", System.IO.FileMode.Create);
        SerializableMeshInfo smi = new SerializableMeshInfo(myMesh);
        bf.Serialize(fs, smi);

        m_Path = Application.dataPath;
        Debug.Log("dataPath : " + m_Path);
        fs.Close();
        //Destroy(gameObject);
        //Destroy(gameObject.GetComponent<MeshFilter>());
        //GameObject.Destroy(< GameObjectWithMeshFilter >);
        //Destroy(myMesh);
    }
    /// <summary>
    /// Loads a mesh from a binary dump
    /// </summary>
    void MeshUndump()
    {
        if (!System.IO.File.Exists(Application.dataPath + "meshFile.dat"))
        {
            Debug.LogError("meshFile.dat file does not exist.");
            return;
        }
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        System.IO.FileStream fs = new System.IO.FileStream(Application.dataPath + "meshFile.dat", System.IO.FileMode.Open);
        SerializableMeshInfo smi = (SerializableMeshInfo)bf.Deserialize(fs);
        test = smi.GetMesh();
        Debug.Log("dataPath : " + m_Path);
  
        fs.Close();
        Debug.Log("Mesh un dumped");

        //Mesh mesh = new Mesh();
        //mesh = test;

        GetComponent<MeshFilter>().mesh = test;

        MeshCollider col = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;

        GetComponent<MeshRenderer>().material = new Material(shader);
        //this.gameObject.AddComponent<Material>();


        


    }

    
}

