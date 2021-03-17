using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class LocomotionController : MonoBehaviour
{

    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (leftTeleportRay)
        {
            leftTeleportRay.gameObject.SetActive(CheckIfActiated(leftTeleportRay));
        }
        if (rightTeleportRay)
        {
            rightTeleportRay.gameObject.SetActive(CheckIfActiated(rightTeleportRay));
        }
    }

    public bool CheckIfActiated(XRController controller)
    {
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);
        return isActivated;
    }

}
