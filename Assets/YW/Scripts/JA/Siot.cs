using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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
        public bool isRadiusTest;
        public bool isHeightTest;

        private const string LEFT_HAND_TAG = "HandLeft";
        private const string RIGHT_HAND_TAG = "HandRight";

        private void Awake()
        {
            GenerateMesh(startRadius, startHeight);
        }

        void Update()
        {
            if (isRadiusTest)
            {
                RadiusRighthand();
                GenerateMesh(changeRadius, changeHeight);
                isRadiusTest = false;
            }

            if (isHeightTest)
            {
                HeightLefthand();
                GenerateMesh(changeRadius, changeHeight);
                isHeightTest = false;
            }
            
        }

        void GenerateMesh(float radius, float height)
        {
            Debug.Log("generateMesh");
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

        public void TriggerRadiusHeightAdjust()
        {
            isHeightTest = true;
            isRadiusTest = true;
            //var controller = GetComponent<XRGrabInteractable>();
            //XRBaseInteractor interactor = controller.GetOldestInteractorSelecting();

            /*
            if (interactor.tag.Equals(LEFT_HAND_TAG))
            {
                isHeightTest = true;
                Debug.Log("왼쪽?");
            }
            else if (interactor.selectingInteractor.tag.Equals(RIGHT_HAND_TAG))
            {
                isRadiusTest = true;
                Debug.Log("오른쪽?");
            }
            */
        }

        // 오른손 레이 닿은 오브젝트의 radius 바뀜, 트리거 버튼으로 값 조절
        bool isIncreasing = true;
        private void RadiusRighthand()
        {
            ischangeValue = true;

            if ((isIncreasing && changeRadius >= radiusRange.y) || (!isIncreasing && changeRadius <= radiusRange.x))
            {
                isIncreasing = !isIncreasing; // 방향을 바꿈
                changeRadius += isIncreasing ? SelectRadiusInterval() : -SelectRadiusInterval();
            }
            else
            {
                changeRadius += isIncreasing ? SelectRadiusInterval() : -SelectRadiusInterval();
            }

            Debug.Log("changeRadius" + changeRadius);
        }

        bool isHeightIncrease = true;
        private void HeightLefthand()
        {
            ischangeValue = true;

            if ((isHeightIncrease && changeHeight >= heightRange.y) || (!isHeightIncrease && changeHeight <= heightRange.x))
            {
                isHeightIncrease = !isHeightIncrease; // 방향을 바꿈
                changeHeight += isHeightIncrease ? SelectHeightInterval() : -SelectHeightInterval();
            }
            else
            {
                changeHeight += isHeightIncrease ? SelectHeightInterval() : -SelectHeightInterval();
            }
            Debug.Log("changeHeight" + changeHeight);
        }

        float SelectRadiusInterval()
        {
            changeRadius = startRadius;
            float interval = radiusRange.y - radiusRange.x;
            interval /= radiusInterval;
            return interval;
        }

        float SelectHeightInterval()
        {
            changeHeight = startHeight;
            float interval = heightRange.y - heightRange.x;
            interval /= heightInterval;
            return interval;
        }
    }
}