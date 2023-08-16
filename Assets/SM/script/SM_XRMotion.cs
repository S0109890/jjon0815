using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System.Linq;




public class SM_XRMotion : MonoBehaviour
{
    private XRRayInteractor rayInteractor;
    private XRController controller;
    private Vector3 previousHandPosition;

    private const float x_max_mov = 0.2f; // 30cm in Unity units
    public float y_max_mov = 0.4f;

    //sm
    private Vector3 previousLeftHandPosition;
    private Vector3 previousRightHandPosition;
    private XRController leftHandController;
    private XRController rightHandController;
    //
    private void Awake()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        controller = GetComponent<XRController>();

        //rayInteractor.onSelectEnter.AddListener(HandleSelectEntered);
        //sm


        //
    }

    private void Start()
    {
        if (leftHandController == null)
            leftHandController = FindObjectsOfType<XRController>().FirstOrDefault(controller => controller.controllerNode == XRNode.LeftHand);
        //Debug.Log("start���� �־��ְ�.");
        rightHandController = FindObjectsOfType<XRController>().FirstOrDefault(controller => controller.controllerNode == XRNode.RightHand);
    }


    private void Update()
    {
        //sm
        //if (leftHandController != null)
        //{
        //    if (leftHandController.inputDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 currentLeftHandPosition))
        //    {
        //        if (Mathf.Abs(currentLeftHandPosition.y - previousLeftHandPosition.y) >= max_mov)
        //        {
        //            print("���� ��������");
        //        }
        //        previousLeftHandPosition = currentLeftHandPosition;
        //    }
        //}

        //if (rightHandController != null)
        //{
        //    if (rightHandController.inputDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 currentRightHandPosition))
        //    {
        //        if (Mathf.Abs(currentRightHandPosition.y - previousRightHandPosition.y) >= max_mov)
        //        {
        //            print("���� 222222222222������ !");

        //        }
        //        previousRightHandPosition = currentRightHandPosition;
        //    }
        //}
        //
        if (controller)
        {
            Vector3 currentHandPosition = controller.transform.position;

            // y�������� �������� movementThreshold�� �ʰ��ϴ��� Ȯ��
            if (Mathf.Abs(currentHandPosition.y - previousHandPosition.y) >= y_max_mov)
            {
                //THISSS();
                //SizeConfig.Instance.isRadiusChange = true;
                //print("���տ�����");
            }
            // x�������� �������� 20cm�� �ʰ��ϴ��� Ȯ��
            if (Mathf.Abs(currentHandPosition.x - previousHandPosition.x) >= x_max_mov)
            {
                //print("�����ʿ���");
            }

            previousHandPosition = currentHandPosition;
        }
        //trigger
        CheckTriggerInput();
    }

    private float leftTriggerLastPressed = -1f;
    private float rightTriggerLastPressed = -1f;
    private float cooldownDuration = 0.5f; // 1 second cooldown
    void CheckTriggerInput()
    {
        /*
        if (leftHandController == null)
            leftHandController = FindObjectsOfType<XRController>().FirstOrDefault(controller => controller.controllerNode == XRNode.LeftHand);

        
        }*/

        if (leftHandController != null)
        {
            if (leftHandController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool leftTriggerValue) && leftTriggerValue)
            {
                // Check if enough time has passed since the last left trigger press
                if (Time.time - leftTriggerLastPressed > cooldownDuration)
                {
                    SizeConfig.Instance.isRadiusChange = true;
                    //print("I pressed my left hand");
                    leftTriggerLastPressed = Time.time;  // Update the last pressed time
                }
            }
        }

        if (rightHandController != null)
        {
            if (rightHandController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool rightTriggerValue) && rightTriggerValue)
            {
                // Check if enough time has passed since the last right trigger press
                if (Time.time - rightTriggerLastPressed > cooldownDuration)
                {
                    SizeConfig.Instance.isHeightChange = true;
                    //print("I pressed my right hand");
                    rightTriggerLastPressed = Time.time;  // Update the last pressed time
                }
            }
        }

    }

    

}