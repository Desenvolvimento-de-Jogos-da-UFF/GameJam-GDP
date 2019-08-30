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
    bool Up = false;
    bool jump = false;

    bool shoot = true;
    [SerializeField] private float shootDelay = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    IEnumerator fireRate()
    {
        shoot = false;
        yield return new WaitForSeconds(shootDelay);
        shoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;
        jump = Input.GetKeyDown(KeyCode.Space);
        Up = Input.GetKey(KeyCode.UpArrow);


        if (Input.GetKey(KeyCode.LeftControl) && shoot)
        {
            Debug.Log(Up);
            controller.shoot(Up, false);
            StartCoroutine(fireRate());
        }
        

    }

    void FixedUpdate() {

        // Move the character
        controller.move(horizontalMove, jump);

        if (shoot == true)
        {

            //controller.shoot(shoot);

        }
        //Debug.Log(horizontalMove);


    }
}
