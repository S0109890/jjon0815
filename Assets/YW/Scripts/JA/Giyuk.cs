using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralToolkit.Samples
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class Giyuk : MonoBehaviour
    {
        public float radius = 1f;
        public int segment = 16;
        public float height = 2f;


        private void Awake()
        {
            GetComponent<MeshFilter>().mesh = MeshGenerator.Giyuk(radius, segment, height).ToMesh();
            AttachBoxCollider();
        }

        private void Start()
        {

        }

        void Update()
        {
            GetComponent<MeshFilter>().mesh = MeshGenerator.Giyuk(radius, segment, height).ToMesh();
            AttachBoxCollider();
        }

        public void AttachBoxCollider()
        {
            Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
            boxCollider.center = mesh.bounds.center;
            boxCollider.size = mesh.bounds.size;
        }
        public void SetColor()
        {
            JAMOSettings.Instance.SetColor(JAMOSettings.SeasonColor.Spring);
        }
    }
}