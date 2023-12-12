using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpHeight;
    private CharacterController playerController;
    private Vector3 direction;

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
        playerController.Move(direction * Time.deltaTime);
        animator.SetBool("Running", true);
    }
}
