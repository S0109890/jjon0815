using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProceduralToolkit.Samples
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
    public class O : MonoBehaviour
    {
        public float radius = 0.35f;
        public int segment = 8;
        public float height = 2f;


        private void Awake()
        {
            GetComponent<MeshFilter>().mesh = MeshGenerator_02.O(radius, segment, height).ToMesh();
            AttachBoxCollider();
        }

        void Update()
        {
<<<<<<< HEAD

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
                Debug.Log(SizeConfig.changeHeight);
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

            GetComponent<MeshFilter>().mesh = MeshGenerator_02.O(radius, segment, height).ToMesh();
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