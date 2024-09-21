using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    private void FixedUpdate()
    {
            if(Input.GetKey(KeyCode.W)){
                rb.AddForce(rb.transform.forward * speed * 1.5f);
            }

            if(Input.GetKey(KeyCode.S)){
                rb.AddForce(-rb.transform.forward * speed);
            }

            if(Input.GetKey(KeyCode.A)){
                rb.AddForce(-rb.transform.right * strafeSpeed);
            }

            if(Input.GetKey(KeyCode.D)){
                rb.AddForce(rb.transform.right * strafeSpeed);
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

    private void OnCollisionEnter(Collision collision){
            if (collision.gameObject.tag == "Floor"){
               isGrounded = true;
            }
        
    }
}
