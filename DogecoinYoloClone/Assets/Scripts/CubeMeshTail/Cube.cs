using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    protected MeshFilter meshFilter;
    protected Mesh mesh;

    public List<GameObject> points;
    public List<Vector3> startPoints;
    public List<Vector3> deltaPoints;
    
    private bool isPress = false;

    private void OnEnable()
    {
        EventManager.OnCubeFinished.AddListener(PressCheck);
    }

    private void OnDisable()
    {
        EventManager.OnCubeFinished.RemoveListener(PressCheck);
    }

    private void Awake()
    {
        points.Add(GameObject.Find("Point0"));
        points.Add(GameObject.Find("Point1"));
        points.Add(GameObject.Find("Point2"));
        points.Add(GameObject.Find("Point3"));

        for (int i = 0; i< points.Count; i++)
        {
            startPoints.Add(points[i].transform.position);
            deltaPoints.Add(points[i].transform.position);
        }
    }

    private void Start()
    {
        mesh = new Mesh();
        mesh.name = "newMesh";

        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshFilter.mesh = mesh;
    }

    private void Update()
    {
        if (!isPress)
        {
            for (int i = 0; i < points.Count; i++)
            {
                deltaPoints[i] = points[i].transform.position;
            }
        }
             
    }

    private void LateUpdate()
    {
        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTriangles();
        mesh.Optimize();       
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    private Vector3[] GenerateVertices()
    {
        return new Vector3[]
        {
            startPoints[0],
            startPoints[1],
            startPoints[2],
            startPoints[3],

            deltaPoints[0],
            deltaPoints[1],
            deltaPoints[2],
            deltaPoints[3],

        };
    }

    private int[] GenerateTriangles()
    {
        return new int[]
        {
            0,1,2,    0,2,3,    // Left
            5,4,6,    6,4,7,    // Right
            1,5,6,    1,6,2,    // Front
            7,0,3,    7,4,0,    // Back
            3,2,6,    3,6,7,    // Bottom
            1,0,5,    5,0,4,    //Top
        };
    }

    void PressCheck()
    {
        isPress = true;
    }
}
