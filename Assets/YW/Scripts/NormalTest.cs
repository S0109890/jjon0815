using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		MeshFilter filter = gameObject.GetComponent(typeof(MeshFilter)) as MeshFilter;
		if (filter != null)
		{
			Mesh mesh = filter.mesh;

			Vector3[] normals = mesh.normals;
			for (int i = 0; i < normals.Length; i++)
				normals[i] = -normals[i];
			mesh.normals = normals;

			for (int m = 0; m < mesh.subMeshCount; m++)
			{
				int[] triangles = mesh.GetTriangles(m);
				for (int i = 0; i < triangles.Length; i += 3)
				{
					int temp = triangles[i];
					triangles[i] = triangles[i + 2];
					triangles[i + 2] = temp;
				}
				mesh.SetTriangles(triangles, m);
			}
		}

	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
