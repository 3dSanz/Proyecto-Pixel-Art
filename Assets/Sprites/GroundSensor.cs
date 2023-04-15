using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    private PlayerController controller;
    public bool isGrounded;
    GameManager gameManager;

    private void Awake() {
        controller = GetComponentInParent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.layer==3){
          isGrounded = true;
          controller.anim.SetBool("IsJumping", false);     
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.layer==3){
         isGrounded = false;  
         controller.anim.SetBool("IsJumping", true);
        }
    }
}
