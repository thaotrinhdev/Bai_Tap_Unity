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
    private Vector3 direction = Vector3.zero;

    public float gravity = -9.81f;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private bool isSliding = false;
    public float slideDuration = 1.5f;

    private int desiredLane = 1;//0: left  1: middle  2: right
    public float laneDistance = 2.5f; // the distance between two lane
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
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
        animator.SetBool("Jump", false);
        if (isGrounded && direction.y < 0)
            direction.y = -1f;
       if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            } 
            if (Input.GetKeyDown(KeyCode.DownArrow) && !isSliding)
                StartCoroutine(Slide());
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.DownArrow) && !isSliding)
            {
                StartCoroutine(Slide());
                direction.y = -10;
            }

        }
        playerController.Move(direction * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
            animator.SetBool("Running_left", true);
            animator.SetBool("Running_right", false);
            animator.SetBool("Running", false);
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
            animator.SetBool("Running_right", true);
            animator.SetBool("Running", false);
            animator.SetBool("Running_left", false);
        }
        direction.y += gravity * Time.deltaTime;
        playerController.Move(direction * Time.deltaTime);
        Vector3 targetPos = transform.position.z * transform.forward + transform.position.y * transform.up;// New P

        if (desiredLane == 0)
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
        else
        {
            playerController.Move(direction * Time.deltaTime);
            animator.SetBool("Running", true);
        }    
    }
    private void Jump()
    {
        StopCoroutine(Slide());
        animator.SetBool("isSliding", false);
        animator.SetBool("Jump",true);
        playerController.center = Vector3.zero;
        playerController.height = 2;
        isSliding = false;

        direction.y = Mathf.Sqrt(jumpHeight * 2 * -gravity);

    }
    private IEnumerator Slide()
    {
        isSliding = true;
        animator.SetBool("isSliding", true);
        yield return new WaitForSeconds(0.25f / Time.timeScale);
        playerController.center = new Vector3(0, -0.5f, 0);
        playerController.height = 1;

        yield return new WaitForSeconds((slideDuration - 0.25f) / Time.timeScale);

        animator.SetBool("isSliding", false);

        playerController.center = Vector3.zero;
        playerController.height = 2;

        isSliding = false;
    }
}
