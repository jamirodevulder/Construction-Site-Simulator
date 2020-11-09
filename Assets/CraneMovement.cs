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
        transform.position += Vector3.right * Time.deltaTime * moveSpeed;
    }
    public void MoveBackward(float makeSpeed)
    {
        float moveSpeed = makeSpeed * 3;
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;
    }
}
