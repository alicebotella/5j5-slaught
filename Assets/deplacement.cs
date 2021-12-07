using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    public CharacterController controler;
    public float speed = 12f;

    void Start()
    {
    }
    // A utiliser pour detecter les touches du clavier
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controler.Move(move * speed * Time.deltaTime);
    }
}
