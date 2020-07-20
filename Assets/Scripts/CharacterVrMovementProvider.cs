using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVrMovementProvider : MonoBehaviour
{
    private CharacterController characterController = null;
    private GameObject head = null;
    protected void Awake()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponentInChildren<OVRCameraRig>().gameObject;

    }
    // Start is called before the first frame update
    void Start()
    {
        PositionController();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PositionController();
    }

    private void PositionController()
    {
        // Get the head in local, playspace ground
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);
        //characterController.height = headHeight;

        // Cut in half, add skin
        Vector3 newCenter = Vector3.zero;

        //newCenter.y = characterController.height / 1f;
        //newCenter.y += characterController.skinWidth;

        // Let's move the capsule in local space as well
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;

        // Apply
        characterController.center = newCenter;
    }
}
