using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class PlayerController : NetworkBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;

    public ConfigurableJoint hips;
    public ConfigurableJoint leftUpLeg;
    public ConfigurableJoint leftLeg;
    public ConfigurableJoint rightUpLeg;
    public ConfigurableJoint rightLeg;
    public ConfigurableJoint spine1;
    public ConfigurableJoint rightArm;
    public ConfigurableJoint rightForeArm;
    public ConfigurableJoint head;
    public ConfigurableJoint leftArm;
    public ConfigurableJoint leftForeArm;

    public Rigidbody rb;
    private bool isGrounded = false;

    public override void OnStartClient()
    { 
        base.OnStartClient();
        if(base.IsOwner){
            rb = GetComponent<Rigidbody>();
        }
 
        if (!base.IsOwner)
        {
            return;
        }

    }

    void Start()
    {
        
    }

    
    private void FixedUpdate()
    {
        if(base.IsOwner){
            if(Input.GetKey(KeyCode.W)){
                rb.AddForce(rb.transform.forward * speed * 1.5f);
            }

            if(Input.GetKey(KeyCode.S)){
                rb.AddForce(-rb.transform.forward * speed);
            }

            if(Input.GetAxis("Jump") > 0){
                if(isGrounded){
                    rb.AddForce(new Vector3(0, jumpForce, 0));
                    isGrounded = false;

                }
            }

            if(Input.GetKey(KeyCode.Q)){
                rb.AddForce(new Vector3(0, -jumpForce, 0));
                isGrounded = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision){
        if(base.IsOwner){
            if (collision.gameObject.tag == "Floor"){
               isGrounded = true;
            }
        }
    }
}
