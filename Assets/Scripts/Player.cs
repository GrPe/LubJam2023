using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _playerTransform;
    public float _speed;
    public List<GameObject> playerAttak=new List<GameObject>();
    public float rateOfAttak = 1f;

    private float timer = 0;

    void Start()
    {
        _playerTransform = transform;
        foreach(GameObject obj in playerAttak)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > rateOfAttak)
        {
            
            if(timer>=rateOfAttak && timer < rateOfAttak + 1)
            {
                        playerAttak[0].SetActive(true);
                        playerAttak[1].SetActive(false);
                        playerAttak[2].SetActive(false);
                        playerAttak[3].SetActive(false);
            }
            else if (timer >= rateOfAttak+1 && timer < rateOfAttak + 2)
            {
                        playerAttak[0].SetActive(false);
                        playerAttak[1].SetActive(true);
                        playerAttak[2].SetActive(false);
                        playerAttak[3].SetActive(false);
                    }
            else if (timer >= rateOfAttak+2 && timer < rateOfAttak + 3)
            {
                        playerAttak[0].SetActive(false);
                        playerAttak[1].SetActive(false);
                        playerAttak[2].SetActive(true);
                        playerAttak[3].SetActive(false);
            }
            else if (timer >= rateOfAttak+3 && timer < rateOfAttak + 4)
            {
                        playerAttak[0].SetActive(false);
                        playerAttak[1].SetActive(false);
                        playerAttak[2].SetActive(false);
                        playerAttak[3].SetActive(true);
                timer = 0f;
                    
            }

        }
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
