using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speed : MonoBehaviour
{
    public Rigidbody target;

    public float maxSpeed = 0.0f;

    private PlayerMovement player;

    public float minSpeeArrow;
    public float maxSpeeArrow;

    public TMP_Text speedLapel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.speed = target.velocity.magnitude * 3.6f;
        if(speedLapel!= null)
        {
            speedLapel.text = ((int)player.speed) + "km/h";
        }    
    }
}
