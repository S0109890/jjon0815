using ProceduralToolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralBase : MonoBehaviour
{
    public float seatWidth;
    public float legWidth;
    public float seatDepth;
    public float legHeight;

    public Vector3 position;
    Vector3 right;
    Vector3 forward;

    public MeshFilter chairMeshFilter;
    public MeshFilter platformMeshFilter;
    private Mesh chairMesh;
    private Mesh platformMesh;

    private const float platformHeight = 0.05f;
    private const float platformRadiusOffset = 0.5f;

    void Start()
    {
        
    }

    void Update()
    {
        right = Vector3.right * (seatWidth - legWidth) / 2;
        forward = Vector3.forward * (seatDepth - legWidth) / 2;
    }

    MeshDraft BaseMesh()
    {
        var mesh = new MeshDraft { name = "Base" };
        mesh.Add(RightCube(position, legWidth, legHeight));
        return mesh;
    }

    private static MeshDraft RightCube(Vector3 center, float width, float height)
    {
        var draft = MeshDraft.Hexahedron(width, width, height, false);
        draft.Move(center + Vector3.up * height / 2);
        return draft;
    }

    public void GenerateMesh()
    {
        var chairDraft = BaseMesh();
        AssignDraftToMeshFilter(chairDraft, chairMeshFilter, ref chairMesh);

        float platformRadius = Geometry.GetCircumradius(seatWidth, seatDepth) + platformRadiusOffset;
        var platformDraft = Platform(platformRadius, platformHeight);
        AssignDraftToMeshFilter(platformDraft, platformMeshFilter, ref platformMesh);
    }

    public  void AssignDraftToMeshFilter(MeshDraft draft, MeshFilter meshFilter, ref Mesh mesh)
    {
        if (mesh == null)
        {
            mesh = draft.ToMesh();
        }
        else
        {
            draft.ToMesh(mesh);
        }
        meshFilter.sharedMesh = mesh;
    }

    public static MeshDraft Platform(float radius, float height, int segments = 128)
    {
        float segmentAngle = 360f / segments;
        float currentAngle = 0;

        var lowerRing = new List<Vector3>(segments);
        var upperRing = new List<Vector3>(segments);
        for (var i = 0; i < segments; i++)
        {
            lowerRing.Add(Geometry.PointOnCircle3XZ(radius + height, currentAngle) + Vector3.down * height);
            upperRing.Add(Geometry.PointOnCircle3XZ(radius, currentAngle));
            currentAngle += segmentAngle;
        }

        var platform = new MeshDraft { name = "Platform" }
            .AddFlatQuadBand(lowerRing, upperRing, false);

        lowerRing.Reverse();
        platform.AddTriangleFan(lowerRing, Vector3.down)
            .Paint(new Color(0.5f, 0.5f, 0.5f, 1));

        platform.Add(new MeshDraft()
            .AddTriangleFan(upperRing, Vector3.up)
            .Paint(new Color(0.8f, 0.8f, 0.8f, 1)));

        return platform;
    }
}
