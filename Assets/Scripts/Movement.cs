using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Movement : MonoBehaviour
{
    private InputDevice device;
    private List<InputDevice> HandDevices = new List<InputDevice>();
    [SerializeField] private InputDeviceCharacteristics deviceCharacteristics;
    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;
    private float gravity = -9.81f;
    private float fallingSpeed;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<XRRig>();
        character = GetComponent<CharacterController>();
        InputDevices.GetDevicesWithCharacteristics(deviceCharacteristics, HandDevices);
        if (HandDevices.Count == 1)
        {
            device = HandDevices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }
    private void FixedUpdate()
    {
        Quaternion head = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = head * new Vector3(inputAxis.x, 0, inputAxis.y);
        character.Move(direction * Time.fixedDeltaTime * speed);

        bool grounded = CheckIfGrounded();
        if (grounded)
            fallingSpeed = 0;
        else
            fallingSpeed += gravity * Time.fixedDeltaTime;

        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }
    private bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hit, rayLength, groundLayer);
        return hasHit;
    }
}
