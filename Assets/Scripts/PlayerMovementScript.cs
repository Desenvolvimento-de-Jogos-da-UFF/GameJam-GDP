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
    bool upShot = false;
    bool downShot = false;
    bool jump = false;
    bool fire = false;

    bool shoot = true;
    [SerializeField] private float shootDelay = 1;

    [SerializeField] private float chargedDelay = 1;
    private float chargedCur = 0;
    private bool chargedShot = false;

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
        upShot = Input.GetKey(KeyCode.W);
        downShot = Input.GetKey(KeyCode.S);
        fire = Input.GetKeyUp(KeyCode.K);


        chargedCur += Time.deltaTime;

    }

    void FixedUpdate() {

        // Move the character
        controller.move(horizontalMove, jump);

        if(fire)
        {

            if(chargedCur >= chargedDelay)
            {

                chargedShot = true;

            }

           
            if (shoot)
            {

                controller.shoot(upShot, downShot, chargedShot);
                chargedCur = 0;
                chargedShot = false;
                StartCoroutine(fireRate());

            }
            

        }


    }
}
