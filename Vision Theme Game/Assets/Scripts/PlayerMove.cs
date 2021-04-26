using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour

{
    Rigidbody rb;
    public float jumpForce = 7;
     public LayerMask groundLayers;
    public SphereCollider col;

    public float speed;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    void Move()
    {

        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        // Returns a copy of vector with its magnitude clamped to maxLength
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        // Transforms direction from local space to world space.
        movement = transform.TransformDirection(movement);
        rb.AddForce(movement);
    }

    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z
             ), col.radius * .9f, groundLayers);

    }
}
