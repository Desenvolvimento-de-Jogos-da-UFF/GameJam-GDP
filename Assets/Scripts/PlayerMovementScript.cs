using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    public CharacterController2 controller;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] public float jumpForce = 20f;
    [SerializeField] public bool isGrounded;

    float horizontalMove = 0f;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        jump = Input.GetKeyDown("up");

    }

    void FixedUpdate() {

        // Move the character
        controller.move(horizontalMove, jump);
        //Debug.Log(horizontalMove);


    }
}
