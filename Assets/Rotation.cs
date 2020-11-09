using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Rotation : MonoBehaviour
{
    private InputDevice device;
    private List<InputDevice> HandDevices = new List<InputDevice>();
    [SerializeField] private InputDeviceCharacteristics deviceCharacteristics;
    [SerializeField] private GameObject camera;
    private Vector2 inputAxis;
    [SerializeField] private float snapIncrement = 1;
    // Start is called before the first frame update
    void Start()
    {
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
        print(inputAxis.x);
        if(inputAxis.x < -0.3)
            this.transform.RotateAround(camera.transform.position, Vector3.up, -Mathf.Abs(snapIncrement));
        if (inputAxis.x > 0.3)
            this.transform.RotateAround(camera.transform.position, Vector3.up, Mathf.Abs(snapIncrement));
    }
}
