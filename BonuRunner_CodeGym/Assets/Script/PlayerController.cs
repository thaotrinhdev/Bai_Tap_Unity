using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpHeight;
    private CharacterController playerController;
    private Vector3 direction;

    private int desiredLane = 1;//0: left  1: middle  2: right
    public float laneDistance = 2.5f ; // the distance between two lane
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        direction.z = playerSpeed;
        Movement();
    }    
    public void Movement()
    {
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
            //animator.SetBool("Running_left", true);
            //animator.SetBool("Running", false);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
            //animator.SetBool("Running_right", true);
            //animator.SetBool("Running", false);
        }
        Vector3 targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;// New P

        if(desiredLane == 0) 
        {
            targetPos += Vector3.left * laneDistance;

        }
        else if (desiredLane == 2)
        {
            targetPos += Vector3.right * laneDistance;

        }
        if (transform.position != targetPos)
        {
            Vector3 diff = targetPos - transform.position;
            Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
            if (moveDir.sqrMagnitude < diff.magnitude)
                playerController.Move(moveDir);
            else
                playerController.Move(diff);
        }
        playerController.Move(direction * Time.deltaTime);
        animator.SetBool("Running", true);
    }
}
