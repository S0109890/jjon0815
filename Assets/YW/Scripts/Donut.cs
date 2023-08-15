using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class Donut : MonoBehaviour
{
    private Mesh _mesh;
    Vector3[] _vertices; //these are stored to avoid recalculating every time
    Vector3[] _rotatedvertices; //these are sent to mesh when changes happen
    int[] _triangles;

    public Vector3 DonutCenter;
    public int DonutSides; //donut resolution
    public int CircleSides; //circle resolution
    public float CircleRadius; //donut thickness
    public float DonutRadius; //donut size
    public Vector3 DonutRotation;

    //cache previous variables
    //need to find a cleaner way to do this
    //maybe a generic that holds two states?    
    Vector3 lastDonutCenter;
    int lastDonutSides;
    int lastCircleSides;
    float lastCircleRadius;
    float lastDonutRadius;
    Vector3 lastDonutRotation;

    void Start()
    {
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        _mesh = new Mesh();
        meshFilter.mesh = _mesh;

        _vertices = GenerateDonutVertices();
        _triangles = GenerateDonutTriangles(_rotatedvertices);

        _rotatedvertices = RotateVertices(_vertices, DonutRotation);

        _mesh.vertices = _rotatedvertices;
        _mesh.triangles = _triangles;
    }

    void Update()
    {
        //ideally handle origin shift separately as well
        OverwriteLastVariables(out bool variablesChanged, out bool trianglesChanged, out bool rotationChanged);
        if (variablesChanged)
        {
            _vertices = GenerateDonutVertices();
        }
        if (trianglesChanged)
        {
            _triangles = GenerateDonutTriangles(_vertices); //triangles only change if CircleSides/DonutSides changes
        }
        if (variablesChanged || rotationChanged)
        {
            _rotatedvertices = RotateVertices(_vertices, DonutRotation);
            _mesh.vertices = _rotatedvertices;
        }
        if (trianglesChanged)
        {
            _mesh.triangles = _triangles;
        }
    }

    void OverwriteLastVariables(out bool variablesChanged, out bool trianglesChanged, out bool rotationChanged)
    {
        variablesChanged = false;
        trianglesChanged = false;
        rotationChanged = false;
        if (lastDonutSides != DonutSides || lastCircleSides != CircleSides)
        {
            variablesChanged = true;
            trianglesChanged = true;
            rotationChanged = true;
            lastDonutSides = DonutSides;
            lastCircleSides = CircleSides;
        }
        if (lastDonutCenter != DonutCenter || lastCircleRadius != CircleRadius || lastDonutRadius != DonutRadius)
        {
            variablesChanged = true;
            lastDonutCenter = DonutCenter;
            lastCircleRadius = CircleRadius;
            lastDonutRadius = DonutRadius;
        }
        if (lastDonutRotation != DonutRotation)
        {
            rotationChanged = true;
            lastDonutRotation = DonutRotation;
        }
    }

    //Generates vertices and triangles for a donut that sits on the xz plane
    void GenerateDonut(out Vector3[] vertices, out int[] triangles)
    {
        vertices = GenerateDonutVertices();
        triangles = GenerateDonutTriangles(vertices);
    }

    
    Vector3[] GenerateDonutVertices()
    {
        // Calculate the offset for circle's center to ensure it's in the first quadrant
        float offsetX = DonutRadius - CircleRadius;
        float offsetZ = 0; // You can adjust this value if needed

        // Make a circle shifted by offset amount away from DonutCenter to the right 
        // This makes it so that the circle faces are perpendicular to the line between it and donut center
        Vector3[] circleVertices = GenerateCircleVertices(new Vector3(offsetX, 0, offsetZ));

        // Make a copy of the circle rotated/positioned for each donut step and add it to a vertices list
        List<Vector3> donutVertices = new List<Vector3>();
        float degreesPerStep = (float)360 / DonutSides;
        for (int i = 0; i < DonutSides; i++)
        {
            float currentDegree = degreesPerStep * i;
            foreach (Vector3 vertex in circleVertices)
            {
                Vector3 rotationVector = Vector3.up * currentDegree;
                Quaternion rotationQuaternion = Quaternion.Euler(rotationVector);

                // Rotate the vertices of the circle template
                Vector3 newVertex = rotationQuaternion * (vertex - DonutCenter) + DonutCenter;
                donutVertices.Add(newVertex);
            }
        }

        return donutVertices.ToArray();
    }

    //generates an n-polygon of n = _circleSides and radius = _circleRadius centered at circleCenter
    Vector3[] GenerateCircleVertices(Vector3 circleCenter)
    {
        Vector3[] vertices = new Vector3[CircleSides];
        float circumferenceProgressPerStep = (float)1 / CircleSides;
        float TAU = 2 * Mathf.PI;
        float radianProgressPerStep = circumferenceProgressPerStep * TAU;

        for (int i = 0; i < CircleSides; i++)
        {
            float currentRadian = radianProgressPerStep * i;
            float x = circleCenter.x + Mathf.Cos(currentRadian) * CircleRadius;
            float y = circleCenter.y + Mathf.Sin(currentRadian) * CircleRadius;
            float z = circleCenter.z;
            vertices[i] = new Vector3(x, y, z);
        }

        return vertices;
    }

    int[] GenerateDonutTriangles(Vector3[] vertices)
    {
        List<int> triangleIndexes = new List<int>();
        int n = CircleSides;
        for (int circle = 0; circle < DonutSides; circle++)
        {
            for (int i = 0; i < n; i++)
            {
                //calculate indexes of first circle
                int firstOfFirstCircle = circle * n;
                int firstIndex = firstOfFirstCircle + i;
                int secondIndex = firstOfFirstCircle + (i + 1) % n;

                //calculate indexes of second circle
                int firstOfSecondCircle = ((circle + 1) % DonutSides) * n;
                int thirdIndex = firstOfSecondCircle + i;
                int fourthIndex = firstOfSecondCircle + ((i + 1) % n);

                //triangle 1
                triangleIndexes.Add(firstIndex);
                triangleIndexes.Add(thirdIndex);
                triangleIndexes.Add(fourthIndex);

                //triangle 2
                triangleIndexes.Add(firstIndex);
                triangleIndexes.Add(fourthIndex);
                triangleIndexes.Add(secondIndex);
            }
        }
        return triangleIndexes.ToArray();
    }

    Vector3[] RotateVertices(Vector3[] vertices, Vector3 donutRotation)
    {
        Vector3[] rotatedVertices = vertices.Clone() as Vector3[];
        Quaternion donutRotationQuaternion = Quaternion.Euler(donutRotation);
        for (int i = 0; i < vertices.Length; i++)
        {
            rotatedVertices[i] = donutRotationQuaternion * (vertices[i] - DonutCenter) + DonutCenter;
        }
        return rotatedVertices;
    }
}