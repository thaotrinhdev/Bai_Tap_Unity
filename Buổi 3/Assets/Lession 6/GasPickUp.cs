using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPickUp : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            var rc = other.GetComponent<Move_Lession6>();
            rc.PickUpGas();
            Destroy(gameObject);
        }    
    }
}
