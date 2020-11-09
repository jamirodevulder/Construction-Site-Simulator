using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{
    [SerializeField] private CraneMovement craneMovement;
    void Update()
    {
        print(transform.localEulerAngles.y);
        float sum = transform.rotation.eulerAngles.x * 0.01f - 2.7f + 0.4f;
        if (transform.localEulerAngles.y < 95 && sum > 0.65f)
        {
            craneMovement.MoveBackward(-sum);
        }
        else if(sum > 0.65f)
        {
            craneMovement.MoveForward(-sum);
        }
    }
    public void lookat(Transform t)
    {
        var lookPos =  t.position - transform.position;
        lookPos.z = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        if(rotation.x < -0.15)
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 10f);
    }
    
}
