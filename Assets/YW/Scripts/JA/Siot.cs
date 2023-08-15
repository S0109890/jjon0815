using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralToolkit.Samples
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class Siot : MonoBehaviour
    {
        [Header("Radius")]
        public float startRadius = 0.08f;
        public float changeRadius = 0.08f;
        public Vector2 radiusRange = new Vector2(0.08f, 0.18f);
        public int radiusInterval = 5;

        [Header("Height")]
        public float startHeight = 0.08f;
        public float changeHeight = 0;
        public Vector2 heightRange = new Vector2(1.2f, 5f);
        public int heightInterval = 3;

        [Header("Segment")]
        public int segment = 8;


        bool ischangeValue;
        public bool isTest;

        private void Awake()
        {
            GenerateMesh(startRadius, startHeight);
        }

        void Update()
        {
            if (isTest)
            {
                RadiusRighthand();
                isTest = false;
            }

            if (!ischangeValue) return;
            if (startRadius != changeRadius || startHeight != changeHeight)
            {
                GenerateMesh(changeRadius, changeHeight);
                ischangeValue = false;
            }

            
        }

        void GenerateMesh(float radius, float height)
        {
            GetComponent<MeshFilter>().mesh = MeshGenerator.Siot(radius, segment, height).ToMesh();
            AttachBoxCollider();
        }
        public void AttachBoxCollider()
        {
            Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
            boxCollider.center = mesh.bounds.center;
            boxCollider.size = mesh.bounds.size;
        }

        // Hover 닿으면 색깔 바뀜
        public void SetColor()
        {
            JAMOSettings.Instance.SetColor(JAMOSettings.SeasonColor.Fall);
        }

        // 오른손 레이 닿은 오브젝트의 radius 바뀜, 트리거 버튼으로 값 조절
        bool isIncreasing = true;
        public void RadiusRighthand()
        {
            ischangeValue = true;

            //changeRa
        }

        float SelectInterval()
        {
            changeRadius = startRadius;
            float interval = radiusRange.y - radiusRange.x;
            return interval;
        }
    }
}