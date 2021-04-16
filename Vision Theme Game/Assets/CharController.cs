using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharController : MonoBehaviour

   
{
    [SerializeField]
    float moveSpeed = 4f;
    public LayerMask groundLayers;
    public float jumpForce = 7;
    public SphereCollider col;
    public Rigidbody player;
    

    Vector3 forward, right;

    // Start is called before the first frame update
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
        player = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }
           
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Move()
    {
        Vector3 directon = new Vector3(Input.GetAxis("HorizontalKey"),0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    private bool IsGrounded()
    {
       return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z
            ), col.radius * .9f, groundLayers);

    }
}
