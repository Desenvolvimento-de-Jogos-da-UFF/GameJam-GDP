using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    private float horizontalMove;
    private bool jump;

    private Rigidbody2D selfRigidBody;

   
   // private Transform transform;




    // Start is called before the first frame update
    void Start()
    {

        selfRigidBody = GetComponent<Rigidbody2D>();
        //transform = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal");
        jump = Input.GetKeyDown("up");
        
    }

    void FixedUpdate() {
        
        if(horizontalMove != 0){

            transform.position += new Vector3(moveSpeed * horizontalMove * Time.deltaTime, 0, 0);

        }

        if(jump){

            selfRigidBody.velocity = new Vector2(selfRigidBody.velocity.x, jumpForce);

        }

    }
}
