using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour {

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;
    Color[] colors;

    public float height;

    public int xSize = 20;
    public int zSize = 20;

    public Gradient gradient;

    float minTerrainHeight;
    float maxTerrainHeight;

    public GameObject[] lowHeightObjects;
    public GameObject[] highHeightObjecs;
    public int spawnCount;

    int newNoise;
    // Use this for initialization
    void Start () {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        newNoise = Random.Range(0, 10000);
        height = Random.Range(2.5f, 4f);
        CreateShape();
        UpdateMesh();
        SpawnObjects();
       
        
    }
    private void Update()
    {
        CreateShape();
        UpdateMesh();
    }
    void SpawnObjects()
    {
        for (int i = 0; i <= spawnCount; i++)
        {
            int index = (int)Random.Range(0, mesh.vertexCount);

            Vector3 someRandomlySelectedVertexPosition = mesh.vertices[index];

            Vector3 instancePos = transform.TransformPoint(someRandomlySelectedVertexPosition);

            
            if (instancePos.y > maxTerrainHeight * 0.55)
            {
                if(instancePos.y>maxTerrainHeight * 0.25)
                {
                    int randomGameobject = Random.Range(5, highHeightObjecs.Length);
                    Instantiate(highHeightObjecs[randomGameobject], instancePos, Quaternion.Euler(mesh.normals[index]));
                }      
                else if(instancePos.y < maxTerrainHeight * 0.25)
                {
                    int randomGameobject = Random.Range(0, 4);
                    Instantiate(highHeightObjecs[randomGameobject], instancePos, Quaternion.Euler(mesh.normals[index]));
                }
            }
            else
            {
                if(instancePos.y > maxTerrainHeight * 0.85)
                {
                    int randomGameobject = Random.Range(5, lowHeightObjects.Length);
                    Instantiate(lowHeightObjects[randomGameobject], instancePos, Quaternion.Euler(mesh.normals[index]));
                }
                else if(instancePos.y < maxTerrainHeight * 0.85)
                {
                    int randomGameobject = Random.Range(0, 5);
                    Instantiate(lowHeightObjects[randomGameobject], instancePos, Quaternion.Euler(mesh.normals[index]));
                }
                
            }
        }
        
    }
    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
       

        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <=xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * .3f + newNoise, z * .3f + newNoise) * height;
                vertices[i] = new Vector3(x, y, z);

                if (y > maxTerrainHeight)
                {
                    maxTerrainHeight = y;
                }
                if (y < minTerrainHeight)
                {
                    minTerrainHeight = y;
                }

                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
        colors = new Color[vertices.Length];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, vertices[i].y);
                colors[i] = gradient.Evaluate(height);
                i++;
            }
        }
    }

    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.colors = colors;

        mesh.RecalculateNormals();
    }
   
   //private void OnDrawGizmos()
   //{
   //    if (vertices == null)
   //        return;
   //
   //    for (int i = 0; i < vertices.Length; i++)
   //    {
   //        Gizmos.DrawSphere(vertices[i], .1f);
   //    }
   //}
}
