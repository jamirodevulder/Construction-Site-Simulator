﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandHandler : MonoBehaviour
{
    private InputDevice device;
    private List<InputDevice> HandDevices = new List<InputDevice>();
    [SerializeField] private InputDeviceCharacteristics deviceCharacteristics;
    [SerializeField] private GameObject HandModel;
    private GameObject spawnedHand;

    // Start is called before the first frame update
    void Start()
    {
        InputDevices.GetDevicesWithCharacteristics(deviceCharacteristics, HandDevices);
        if(HandDevices.Count == 1)
        {
            device = HandDevices[0];
            spawnedHand = Instantiate(HandModel, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.9f)
        {
            Debug.Log("Trigger button is pressed.");
        }
    }
}
