using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bullet;
    

    private Animator animator;

    [SerializeField] private SpriteRenderer sprite;
    private PlayerMovementScript selfMovementScript;
    private Rigidbody2D selfRigidBody;

    private void Awake() {

        selfRigidBody = GetComponent<Rigidbody2D>();
        selfMovementScript = GetComponent<PlayerMovementScript>();
        animator = GetComponentInChildren<Animator>();
       
    }

    public void move(float moveSpeed, bool jump) {

        Vector3 movement = new Vector3(moveSpeed, 0, 0);
        transform.position += movement * Time.deltaTime;

        if(moveSpeed<0){
            transform.localEulerAngles = new Vector3(0, 180, 0);
            //sprite.flipX = true;
            //animator.SetBool("isRunning", true);
        }else if(moveSpeed > 0){
            transform.localEulerAngles = new Vector3(0, 0, 0);
            //sprite.flipX = false;
            //animator.SetBool("isRunning", true);
        }else{
            //animator.SetBool("isRunning", false);
        }

        
        

        if (jump && selfMovementScript.isGrounded){
            //selfRigidBody.AddForce(new Vector2(0f, selfMovementScript.jumpForce), ForceMode2D.Impulse);
            selfRigidBody.velocity = new Vector2(selfRigidBody.velocity.x, selfMovementScript.jumpForce);
            //animator.SetTrigger("Jump");
            Debug.Log("SetTrigger");
        }
            
    }

    public void shoot(bool upShot, bool downShot, bool charged)
    {

        Debug.Log(charged);

        if (upShot == true)
        {

            Debug.Log("UP");
            GameObject bulletUp = Instantiate(bullet, ceilingCheck);
            bulletUp.transform.parent = null;
            bulletUp.transform.position = ceilingCheck.position;
            bulletUp.transform.rotation = ceilingCheck.rotation;

        }

        else if(downShot == true)
        {

            GameObject bulletDown = Instantiate(bullet, groundCheck);
            bulletDown.transform.parent = null;
            bulletDown.transform.position = groundCheck.position;
            bulletDown.transform.rotation = groundCheck.rotation;

        }

        else
        {
            GameObject bulletInstance = Instantiate(bullet, shootPoint);
            bulletInstance.transform.parent = null;
            bulletInstance.transform.position = shootPoint.position;
        }



    }
}
