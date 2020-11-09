using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PickUpItems : MonoBehaviour
{
    private InputDevice device;
    private List<InputDevice> HandDevices = new List<InputDevice>();
    [SerializeField] private LayerMask itemLayer;
    [SerializeField] private InputDeviceCharacteristics deviceCharacteristics;
    private GameObject itemInHand;
    private Rigidbody rbItemInHand;
    private Lever thisLever;
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
        if (itemInHand != null)
        {
            if (device.TryGetFeatureValue(CommonUsages.trigger, out float RtriggerValue) && RtriggerValue < 0.9f)
            {
                ReleaseItem();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 9 && device.TryGetFeatureValue(CommonUsages.trigger, out float AtriggerValue) && AtriggerValue > 0.9f && itemInHand == null)
        {
            pickUpItem(other);
        }
        if(other.gameObject.layer == 11 && device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.9f && itemInHand == null)
        {
            UseLever(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 11 && device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.9f && itemInHand == null)
        {
            thisLever = null;
        }
    }
    private void UseLever(Collider other)
    {
        print("test");
        if(thisLever == null)
            thisLever = other.gameObject.GetComponent<Lever>();
        thisLever.lookat(transform);
    }
    private void pickUpItem(Collider other)
    {
        other.transform.parent = gameObject.transform;
        other.transform.position = transform.position;
        itemInHand = other.gameObject;
        rbItemInHand = itemInHand.GetComponent<Rigidbody>();
        rbItemInHand.isKinematic = true;
    }
    private void ReleaseItem()
    {
        itemInHand.transform.parent = null;
        itemInHand = null;
        rbItemInHand.isKinematic = false;
        rbItemInHand = null;
    }
}
