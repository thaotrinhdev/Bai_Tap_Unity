using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Player_Movement : MonoBehaviour
{
    private GameObject gameObject;
    private Vector3 playerVelocity;
    private bool groundPlayer;
    private CharacterController characterController;
    private Rigidbody rb;
    private Transform car;
    public float speed = 4f;

    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 backward = new Vector3(0, 0, -1);

    Vector3 rotationRight = new Vector3(0, 30, 0);
    Vector3 rotationLeft = new Vector3(0, -30, 0);
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Move01();
    }
    public void Move01()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(backward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationRight);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }
    }
    public void Move02()
    {
        groundPlayer = characterController.isGrounded;
        if (groundPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0;
        }
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move*speed * Time.deltaTime);
        if(move!= Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
