using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Move_Lession6 : MonoBehaviour
{
    private GameObject gameObject;
    private Rigidbody rb;
    private Transform car;
    public float speed = 4f;
    [SerializeField] private float currentFuel = 100;
    [Header("Capacity: 100")]
    [SerializeField] private float currentDamaged = 40;
    [SerializeField] private float laps = 0;


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
        if (currentDamaged <= 0 || currentFuel <= 0)
        {
            Application.LoadLevel(0);
        }
        else
        {
            Move();

        }
        Move();
        currentFuel -= Time.deltaTime;


    }
    public void Laps()
    {
        laps += 1;
    }
    public void PickUpGas()
    {
        currentFuel += 100;
    }
    public void Damage()
    {
        currentDamaged -= 5;
    }
    public void Move()
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

}
