using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using System.Linq;


[RequireComponent(typeof(XRRayInteractor))]
public class SM_XRMotion : MonoBehaviour
{
    private XRRayInteractor rayInteractor;
    private XRController controller;
    private Vector3 previousHandPosition;

    private const float movementThreshold = 0.3f; // 30cm in Unity units

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
        leftHandController = FindObjectsOfType<XRController>().FirstOrDefault(controller => controller.controllerNode == XRNode.LeftHand);
        rightHandController = FindObjectsOfType<XRController>().FirstOrDefault(controller => controller.controllerNode == XRNode.RightHand);

        //
    }


    private void Update()
    {
        //sm
        if (leftHandController != null)
        {
            if (leftHandController.inputDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 currentLeftHandPosition))
            {
                if (Mathf.Abs(currentLeftHandPosition.y - previousLeftHandPosition.y) >= 0.3f)
                {
                    print("���� ��������");
                }
                previousLeftHandPosition = currentLeftHandPosition;
            }
        }

        if (rightHandController != null)
        {
            if (rightHandController.inputDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 currentRightHandPosition))
            {
                if (Mathf.Abs(currentRightHandPosition.y - previousRightHandPosition.y) >= 0.3f)
                {
                    print("���� 222222222222������ !");

                }
                previousRightHandPosition = currentRightHandPosition;
            }
        }
        //
        if (controller)
        {
            Vector3 currentHandPosition = controller.transform.position;

            // y�������� �������� movementThreshold�� �ʰ��ϴ��� Ȯ��
            if (Mathf.Abs(currentHandPosition.y - previousHandPosition.y) >= movementThreshold)
            {
                //THISSS();
                print("���տ�����");
            }

            previousHandPosition = currentHandPosition;
        }
    }

}