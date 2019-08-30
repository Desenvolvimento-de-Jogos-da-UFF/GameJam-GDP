using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{

    GameObject player;

    PlayerMovementScript movementScript;

    // Start is called before the first frame update
    void Start()
    {
        
        player = gameObject.transform.parent.gameObject;
        movementScript = player.GetComponent<PlayerMovementScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D other) {

        if (other.collider.tag == "Ground"){
            
            movementScript.isGrounded = true;

        }
        
    }

    private void OnCollisionExit2D(Collision2D other) {

        if (other.collider.tag == "Ground"){

            movementScript.isGrounded = false;
            
        }
        
    }

}
