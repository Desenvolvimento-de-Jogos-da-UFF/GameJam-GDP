using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private Transform groundCheck;
    private Animator animator;

    private SpriteRenderer sprite;
    private PlayerMovementScript selfMovementScript;
    private Rigidbody2D selfRigidBody;

    private void Awake() {

        selfRigidBody = GetComponent<Rigidbody2D>();
        selfMovementScript = GetComponent<PlayerMovementScript>();
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();

        

    }

    public void move(float moveSpeed, bool jump) {

        Vector3 movement = new Vector3(moveSpeed, 0, 0);
        transform.position += movement * Time.deltaTime;

        if(moveSpeed<0){
            sprite.flipX = true;
            animator.SetBool("isRunning", true);
        }else if(moveSpeed > 0){
            sprite.flipX = false;
            animator.SetBool("isRunning", true);
        }else{
            animator.SetBool("isRunning", false);
        }

        

        if (jump && selfMovementScript.isGrounded){
            //selfRigidBody.AddForce(new Vector2(0f, selfMovementScript.jumpForce), ForceMode2D.Impulse);
            selfRigidBody.velocity = new Vector2(selfRigidBody.velocity.x, selfMovementScript.jumpForce);
            animator.SetTrigger("Jump");
            Debug.Log("SetTrigger");
        }
            
    }
}
