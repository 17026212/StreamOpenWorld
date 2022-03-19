using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  using System.Runtime.Serialization.Formatters.Binary;
using System;

[System.Serializable]
public class SerializableMeshInfo
{
    [SerializeField]
    public float[] vertices;
    [SerializeField]
    public int[] triangles;
    [SerializeField]
    public float[] uv;
    [SerializeField]
    public float[] uv2;
    [SerializeField]
    public float[] normals;

   // public float _r, _g, _b, _a;
    [SerializeField]
    public float[] colorStore = new float[4] { 1F, 1F, 1F, 1F };
    [SerializeField]
    public SerializableColor[] serializableColors;

    //[SerializeField]
    //public Color[] colors;

    public SerializableMeshInfo(Mesh m) // Constructor: takes a mesh and fills out SerializableMeshInfo data structure which basically mirrors Mesh object's parts.
    {
        vertices = new float[m.vertexCount * 3]; // initialize vertices array.
        for (int i = 0; i < m.vertexCount; i++) // Serialization: Vector3's values are stored sequentially.
        {
            vertices[i * 3] = m.vertices[i].x;
            vertices[i * 3 + 1] = m.vertices[i].y;
            vertices[i * 3 + 2] = m.vertices[i].z;
        }

        //Debug.Log("Vertices length is: " + vertices.Length);


        triangles = new int[m.triangles.Length]; // initialize triangles array
        for (int i = 0; i < m.triangles.Length; i++) // Mesh's triangles is an array that stores the indices, sequentially, of the vertices that form one face
        {
            triangles[i] = m.triangles[i];
        }
        uv = new float[m.uv.Length * 2]; // initialize uvs array
        for (int i = 0; i < m.uv.Length; i++) // uv's Vector2 values are serialized similarly to vertices' Vector3
        {
            uv[i * 2] = m.uv[i].x;
            uv[i * 2 + 1] = m.uv[i].y;
        }
        uv2 = new float[m.uv2.Length * 2]; // uv2
        for (int i = 0; i < m.uv2.Length; i++)
        {
            uv[i * 2] = m.uv2[i].x;
            uv[i * 2 + 1] = m.uv2[i].y;
        }

        normals = new float[m.normals.Length * 3]; // normals are very important
        for (int i = 0; i < m.normals.Length; i++) // Serialization
        {
            normals[i * 3] = m.normals[i].x;
            normals[i * 3 + 1] = m.normals[i].y;
            normals[i * 3 + 2] = m.normals[i].z;
        }

        //Debug.Log("Normals length is: " + normals.Length);

        //serializableColors = new SerializableColor[m.colors.Length];
        //colors 
        ////colors
        ////serializableColors = new SerializableColor(m.colors[i]);
        //for (int i = 0; i < m.colors.Length; i++)
        //{
        //    //serializableColors[i].SetColor(m.colors[i]);
        //    //serializableColors[i] = serializableColors.SetColor(m.colors[i]);
        //}

        //colors = new Color[m.colors.Length];
        //Debug.Log("R value: " + m.colors.Length);

        //colorStore = new float[m.colors.Length];
   
        //for (int i = 0; i < m.colors.Length; i++)
        //{
        //    Debug.Log("R value: " + m.colors[i].r);
        //    colorStore[i] = m.colors[i].r;
        //    Debug.Log("R value: " + m.colors[i].r);
        //    colorStore[i] = m.colors[i].g;
        //    colorStore[i] = m.colors[i].b;
        //}


    }



    // GetMesh gets a Mesh object from currently set data in this SerializableMeshInfo object.
    // Sequential values are deserialized to Mesh original data types like Vector3 for vertices.
    public Mesh GetMesh()
    {
        Mesh m = new Mesh();

        List<Vector3> verticesList = new List<Vector3>();
        for (int i = 0; i < vertices.Length / 3; i++)
        {
            verticesList.Add(new Vector3(
                    vertices[i * 3], vertices[i * 3 + 1], vertices[i * 3 + 2]
                ));
        }
        m.SetVertices(verticesList);


        m.triangles = triangles;
        List<Vector2> uvList = new List<Vector2>();
        for (int i = 0; i < uv.Length / 2; i++)
        {
            uvList.Add(new Vector2(
                    uv[i * 2], uv[i * 2 + 1]
                ));
        }
        m.SetUVs(0, uvList);


        List<Vector2> uv2List = new List<Vector2>();
        for (int i = 0; i < uv2.Length / 2; i++)
        {
            uv2List.Add(new Vector2(
                    uv2[i * 2], uv2[i * 2 + 1]
                ));
        }
        m.SetUVs(1, uv2List);


        List<Vector3> normalsList = new List<Vector3>();
        for (int i = 0; i < normals.Length / 3; i++)
        {
            normalsList.Add(new Vector3(
                    normals[i * 3], normals[i * 3 + 1], normals[i * 3 + 2]
                ));
        }
        m.SetNormals(normalsList);
        //colors = colorStore;
        //Color newColor = new Color(colorStore);
        // colorStore[0].GetValue();
        // colorStore[0].GetValue();
        //m.colors[i].b;
        //m.colors = colorStore[0];
        //colors = new Color(0, 0, 0, 1);

        for (int i = 0; i < m.colors.Length; i++)
        {
            m.colors[i] = new Color(0, 0, 0, 1);
        }

        return m;
    }



    [System.Serializable]
    public class SerializableColor
    {
        public float _r, _g, _b, _a;

        public Color GetColor() => new Color(_r, _g, _b, _a);
        public void SetColor(Color color)
        {
            _r = color.r;
            _g = color.g;
            _b = color.b;
            _a = color.a;
        }

        public SerializableColor() { _r = _g = _b = _a = 1f; }

        public SerializableColor(Color color) : this(color.r, color.g, color.b, color.a) { }

        public SerializableColor(float r, float g, float b, float a = 0f)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
        }
    }

}