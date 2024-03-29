using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralToolkit.Samples
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class K : MonoBehaviour
    {
        public float radius = 0.35f;
        public int segment = 8;
        public float height = 2f;


        private void Awake()
        {
            GetComponent<MeshFilter>().mesh = MeshGenerator_02.K(radius, segment, height).ToMesh();
            AttachBoxCollider();
        }

        void Update()
        {
            GetComponent<MeshFilter>().mesh = MeshGenerator_02.K(radius, segment, height).ToMesh();
            AttachBoxCollider();
        }
        public void AttachBoxCollider()
        {
            Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
            boxCollider.center = mesh.bounds.center;
            boxCollider.size = mesh.bounds.size;
        }
    }
}