using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void MoveForward(float makeSpeed)
    {
        float moveSpeed = makeSpeed * 3;
        transform.localPosition += transform.right * Time.deltaTime * moveSpeed;
    }
    public void MoveBackward(float makeSpeed)
    {
        float moveSpeed = makeSpeed * 3;
        transform.localPosition += -transform.right * Time.deltaTime * moveSpeed;
    }
    public void RotateRight(float makeSpeed)
    {
        float minus = makeSpeed * 40 * Time.deltaTime;
        transform.Rotate(0, -minus, 0);
    }
    public void RotateLeft(float makeSpeed)
    {
        transform.Rotate(0, makeSpeed * 40 * Time.deltaTime, 0);
    }
}
