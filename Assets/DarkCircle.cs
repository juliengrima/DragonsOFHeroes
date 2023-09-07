using UnityEngine;
using System.Collections;

public class DarkCircle : MonoBehaviour
{

    public float shrinkTime = 20f; // the time in seconds to shrink the circle
    public float radius = 5f; // the initial radius of the circle
    public Material material; // the material of the circle

    private Mesh mesh; // the mesh of the circle
    private Vector3[] vertices; // the vertices of the circle
    private int[] triangles; // the triangles of the circle
    private float timer; // the timer for shrinking

    void Start()
    {
        // create a new mesh
        mesh = new Mesh();
        mesh.name = "Dark Circle";

        // create a new game object with a mesh filter and a mesh renderer
        GameObject circle = new GameObject("Dark Circle");
        circle.AddComponent<MeshFilter>().mesh = mesh;
        circle.AddComponent<MeshRenderer>().material = material;

        // set the position and rotation of the circle
        circle.transform.position = Vector3.zero;
        circle.transform.rotation = Quaternion.Euler(90, 0, 0);

        // create the vertices and triangles of the circle
        CreateCircle();
    }

    void Update()
    {
        // update the timer
        timer += Time.deltaTime;

        // check if the timer is less than the shrink time
        if (timer < shrinkTime)
        {
            // calculate the new radius based on the timer and the shrink time
            float newRadius = Mathf.Lerp(radius, 0, timer / shrinkTime);

            // update the vertices of the circle with the new radius
            UpdateCircle(newRadius);
        }
    }

    void CreateCircle()
    {
        // calculate the number of segments based on the radius
        int segments = Mathf.FloorToInt(radius * 10);

        // initialize the vertices and triangles arrays
        vertices = new Vector3[segments + 1];
        triangles = new int[segments * 3];

        // set the first vertex to be the center of the circle
        vertices[0] = Vector3.zero;

        // loop through the segments and create the rest of the vertices
        for (int i = 0; i < segments; i++)
        {
            // calculate the angle in radians
            float angle = i * Mathf.PI * 2 / segments;

            // calculate the x and y coordinates of the vertex
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            // set the vertex position
            vertices[i + 1] = new Vector3(x, y, 0);
        }

        // loop through the segments and create the triangles
        for (int i = 0; i < segments; i++)
        {
            // calculate the indices of the vertices for each triangle
            int v1 = 0;
            int v2 = i + 1;
            int v3 = (i + 1) % segments + 1;

            // set the triangle indices
            triangles[i * 3] = v1;
            triangles[i * 3 + 1] = v2;
            triangles[i * 3 + 2] = v3;
        }

        // assign the vertices and triangles to the mesh
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        // recalculate the normals and bounds of the mesh
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }

    void UpdateCircle(float newRadius)
    {
        // calculate the number of segments based on the new radius
        int segments = Mathf.FloorToInt(newRadius * 10);

        // loop through the segments and update the rest of the vertices with the new radius
        for (int i = 0; i < segments; i++)
        {
            // calculate the angle in radians
            float angle = i * Mathf.PI * 2 / segments;

            // calculate the x and y coordinates of the vertex
            float x = Mathf.Cos(angle) * newRadius;
            float y = Mathf.Sin(angle) * newRadius;

            // update the vertex position
            vertices[i + 1] = new Vector3(x, y, 0);
        }

        // assign the updated vertices to the mesh
        mesh.vertices = vertices;

        // recalculate the bounds of the mesh
        mesh.RecalculateBounds();
    }
}