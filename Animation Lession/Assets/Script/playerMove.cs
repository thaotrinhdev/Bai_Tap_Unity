using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Animator animator;
    private Rigidbody rb;
    public float speed;
    public float jumpForce;
    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    // Update is called once per frame
    void Update()
    {
        isGrounded = true;
        Move();
        Jump();

    }
    public void Move()
    {

        var moveX = Input.GetAxis("Horizontal");
        var moveY = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, 0, moveY)*speed*Time.deltaTime;
        if ((move != Vector3.zero))
        {
            Quaternion rot = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, 0.5f * Time.deltaTime);
        }

        if (moveX > 0 || moveX < 0 || moveY > 0 || moveY < 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Cho phép nhân vật nhảy lại khi chạm đất
            isGrounded = true;
        }
    }
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isFalling", true);
            animator.SetBool("isGrounded", true);
            animator.SetBool("isJumping", false);
        }
    }

}
