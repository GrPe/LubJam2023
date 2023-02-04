using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToTarget : MonoBehaviour
{
    private RatMovement _movement;

    // Start is called before the first frame update
    void Start()
    {
        _movement = GetComponent<RatMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_movement.Target.position.x - transform.position.x <= 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
