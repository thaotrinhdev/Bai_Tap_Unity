using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private List<Transform> target;
    private int step = 0;
    // Update is called once per frame
    void Update()
    {
        if (step < target.Count)
        {
            transform.Translate((target[step].position - transform.position).normalized * speed * Time.deltaTime);
            if ((transform.position - target[step].position).magnitude < 0.1f)
            {
                step++;
            }    
        }

    }
}
