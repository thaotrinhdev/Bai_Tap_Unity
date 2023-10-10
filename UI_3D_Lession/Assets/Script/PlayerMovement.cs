using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
using EasyJoystick;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // Gas
    public TMP_Text text;
    public float currentGas = 100;

    //Km
    public TMP_Text textDamage;
    public int damageCount = 0;

    public TMP_Text textSpeed;
    public float speed = 0;
    public Joystick joystick;
    public Health_Bar health;
    public float currentHealth;
    public float maxHealth = 100;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        health.MaxHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        Player_Move();
        currentGas -= Time.deltaTime;
        text.text = currentGas.ToString();
        textDamage.text = damageCount.ToString();
        textSpeed.text = speed + "km/h";

        if (currentHealth <= 0 || currentGas <= 0)
        {
            Application.LoadLevel(1);
        }
        StartCoroutine((string)CalculateSpeed());
    }
    private void Player_Move()
    {
        var movex = joystick.Horizontal();
        var movey = joystick.Vertical();
        //Vector3.forward: Change z
        transform.Translate(Vector3.forward * speed * Time.deltaTime * movey);
        //Vector3.up: Change y
        transform.Rotate(Vector3.up * movex * 70.0f * Time.deltaTime);
    }
    IEnumerable CalculateSpeed()

    {
       Vector3 lastPosition = transform.position;
        yield return new WaitForFixedUpdate();
        speed = (lastPosition - transform.position).magnitude/Time.deltaTime;
    }    
    public void FillGas()
    {
        currentGas+= 20;
    }
    public void Damage()
    {
        Debug.Log("moi di qua 1 cai");
        currentHealth -= 20;
        damageCount += 1;
        health.Health(currentHealth);
    }
}
