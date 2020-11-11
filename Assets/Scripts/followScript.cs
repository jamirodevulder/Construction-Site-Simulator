using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(target.position);
        //transform.position = target.position;
    }
    private void FixedUpdate()
    {
      rb.MovePosition(target.position);
    }
}
