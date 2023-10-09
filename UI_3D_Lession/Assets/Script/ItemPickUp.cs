using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public enum Item
    {
        DamagePlayer, GasIncrean, SpeedIncrean,
    }
    public Item type;
    public void OnItemPickUp(GameObject go)
    {
        switch (type)
        {
            case Item.DamagePlayer:
                go.GetComponent<PlayerMovement>().Damage();
                break;
            case Item.SpeedIncrean:
                go.GetComponent<PlayerMovement>().speed += 5;
                break;
            case Item.GasIncrean:
                go.GetComponent<PlayerMovement>().FillGas();
                break;

        }
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            OnItemPickUp(other.gameObject);
        }
    }
}
