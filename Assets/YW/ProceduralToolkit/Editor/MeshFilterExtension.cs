using UnityEngine;
using UnityEditor;

namespace ProceduralToolkit.Editor
{
    /// <summary>
    /// Mesh saving utility available at `MeshFilter context menu > Save Mesh`
    /// </summary>
    public class MeshFilterExtension
    {
        private const string menuPath = "CONTEXT/MeshFilter/Save Mesh";

        [MenuItem(menuPath)]
        private static void SaveMesh(MenuCommand menuCommand)
        {
            var meshFilter = (MeshFilter) menuCommand.context;
            var mesh = meshFilter.sharedMesh;

            var path = EditorUtility.SaveFilePanelInProject("Save Mesh", mesh.name, "asset", "Save Mesh");
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            AssetDatabase.CreateAsset(mesh, path);
        }

        [MenuItem(menuPath, true)]
        private static bool SaveMeshTest(MenuCommand menuCommand)
        {
            var meshFilter = (MeshFilter) menuCommand.context;
            Mesh mesh = meshFilter.mesh;

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

            return meshFilter.sharedMesh != null;
        }
    }
}
