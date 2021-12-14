using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    public CharacterController controler;
    public Animator animator;
    public float speed = 12f;
    //float chaVelocityX;
    //float chaVelocityZ;
    void Start()
    {

    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controler.Move(move * speed * Time.deltaTime);

        animator.SetFloat("VelocityX", x);
        animator.SetFloat("VelocityZ", z);
    }
}
