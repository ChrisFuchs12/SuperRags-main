using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerEyez : MonoBehaviour
{
    public GameObject lazerEye;
    public float knockback = 100;
    public Rigidbody rb;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.E)){
            lazerEye.SetActive(true);
            rb.AddForce(-rb.transform.forward * knockback);
        }
        if(Input.GetKeyUp(KeyCode.E)){
            lazerEye.SetActive(false);
        }
    }
}
