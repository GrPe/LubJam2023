using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _playerTransform;
    public float _speed;

    void Start()
    {
        _playerTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(h != 0f || v != 0f)
        {
            _playerTransform.position = new Vector2(
                transform.position.x + (Time.deltaTime * h * _speed), 
                transform.position.y + (Time.deltaTime * v * _speed));
        }
    }
}
