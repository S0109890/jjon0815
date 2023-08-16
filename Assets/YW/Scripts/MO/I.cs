using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralToolkit.Samples
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class I : MonoBehaviour
    {
        [Header("Radius")]
        public float startRadius = 0.08f;
        public float changeRadius = 0.08f;

        [Header("Height")]
        public float startHeight = 2.0f;
        public float changeHeight = 2.0f;

        [Header("Segment")]
        public int segment = 8;

        public bool isRadiusTest;
        public bool isHeightTest;


        private void Start()
        {
            startHeight = changeHeight = SizeConfig.Instance.startHeight;
            startRadius = changeRadius = SizeConfig.Instance.startRadius;

            GenerateMesh(startRadius, startHeight);
        }

        bool isRadiusChange;
        bool isHeightChange;
        void Update()
        {

            if (SizeConfig.Instance.isRadiusChange)
            //if (isRadiusTest)
            {
                //*RadiusAdjust 안에 
                changeRadius = SizeConfig.Instance.changeRadius;
                GenerateMesh(changeRadius, changeHeight);
                //*이부분만 넣고 테스트
                isRadiusTest = false;
                isRadiusChange = false;

            }

            if (SizeConfig.Instance.isHeightChange)
            //if (isHeightTest)
            {
                //Debug.Log("height 바꿔주고 있어.");

                changeHeight = SizeConfig.changeHeight;
                GenerateMesh(changeRadius, changeHeight);
                isHeightTest = false;
                isHeightChange = false;
            }
            //changeRadius = SizeConfig.Instance.RadiusRighthand();
            //changeHeight = SizeConfig.Instance.HeightLefthand();
            //GenerateMesh(changeRadius, changeHeight);

        }

        void GenerateMesh(float radius, float height)
        {
            GetComponent<MeshFilter>().mesh = MeshGenerator_02.I(radius, segment, height).ToMesh();
            AttachBoxCollider();
        }

        public void AttachBoxCollider()
        {
            Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;
            BoxCollider boxCollider = gameObject.GetComponent<BoxCollider>();
            //boxCollider.center = mesh.bounds.center;
            //boxCollider.size = mesh.bounds.size;

            float fontColliderLength = changeHeight + changeRadius * 2;
            boxCollider.size = new Vector3(fontColliderLength, fontColliderLength, 5f);
            boxCollider.center = new Vector3(changeHeight * 0.5f, changeHeight * 0.5f, 0);
        }

        // Hover 닿으면 색깔 바뀜
        public void SetColor()
        {
            JAMOSettings.Instance.SetColor(JAMOSettings.SeasonColor.Fall);
        }

        public void RadiusAdjust()
        {
            isRadiusTest = true;
        }

        public void HeightAdjust()
        {
            isHeightTest = true;
        }
    }
}