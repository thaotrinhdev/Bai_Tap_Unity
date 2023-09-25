using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj_Move : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> tagets;
    private int step = 0;

    // Update is called once per frame
    void Update()
    {

        if( step< tagets.Count)
        {
            //normalized: giúp không thay đổi tốc độ khi vật đến gần
            //transform.position: Vị trí hiện tại
            transform.Translate((tagets[step].position -transform.position).normalized*speed*Time.deltaTime);
            if ((transform.position - tagets[step].position).magnitude < 0.1f);
            {
                step++;
            }
        }    
        //if(Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.Translate(new Vector3(0, 0, 1)*speed*Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        //}
    }
}
