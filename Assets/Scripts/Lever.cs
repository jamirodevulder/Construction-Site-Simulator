using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    [SerializeField] private CraneMovement craneMovement;
    private Quaternion startRotation;
    [SerializeField] private bool movement;
    [SerializeField] private bool rotation;
    private bool release = false;
    private void Start()
    {
        startRotation = transform.rotation;
    }
    void Update()
    {
        float sum = transform.rotation.eulerAngles.x * 0.01f - 2.7f + 0.4f;
        if (transform.localEulerAngles.y < 95 && sum > 0.65f)
        {
            CheckWhatLeverNeedsToDoLeft(-sum);
        }
        else if(sum > 0.65f)
        {
            CheckWhatLeverNeedsToDoRight(-sum);
        }
        if(release && transform.rotation != startRotation)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, Time.deltaTime * 100f);
            release = false;
        }
    }
    public void LookAt(Transform t)
    {
        var lookPos =  t.position - transform.position;
        lookPos.z = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        print(rotation);
        if(rotation.x < -0.15)
            transform.localRotation = Quaternion.Slerp(transform.localRotation, rotation, Time.deltaTime * 10f);
    }
    public void LeverRelease()
    {
      //  release = true;
    }
    public void CheckWhatLeverNeedsToDoLeft(float value)
    {
        if (movement)
            craneMovement.MoveBackward(value);
        else if (rotation)
            craneMovement.RotateLeft(value);
    }
    public void CheckWhatLeverNeedsToDoRight(float value)
    {
        if(movement)
         craneMovement.MoveForward(value);
        else if (rotation)
            craneMovement.RotateRight(value);
    }
}
