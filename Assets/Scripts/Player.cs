using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _playerTransform;
    public float _speed;
    public List<GameObject> playerAttak = new List<GameObject>();
    public float rateOfAttak = 1f;
    public int costAttack = 2;
    public ScoresController scoresController;
    public GameObject special;


    private float timer = 0;
    public float energy= 10;
    public TMP_Text energyCount;

    void Start()
    {
        _playerTransform = transform;
        energyCount.text= ((int)energy).ToString();
        foreach (GameObject obj in playerAttak)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (energy < 10)
        {
            energy += Time.deltaTime / 1.5f;
            energyCount.text = ((int)energy).ToString();
        }
        if (timer > rateOfAttak && Input.GetKeyDown(KeyCode.Space) && energy>= costAttack)
        {
            //scoresController.SetScores(-costAttack);
            energy-= costAttack;
            energyCount.text = ((int)energy).ToString();
            playerAttak[0].SetActive(true);
            playerAttak[1].SetActive(true);
            playerAttak[2].SetActive(true);
            playerAttak[3].SetActive(true);
            timer = 0;
            StartCoroutine(DisableAtack());
        }    
        if(Input.GetKeyDown(KeyCode.R))
        {
            special.SetActive(true);
        }
        MovePlayer();
    }

    IEnumerator DisableAtack()
    {
        yield return new WaitForSeconds(.5f);
        playerAttak[0].SetActive(false);
        playerAttak[1].SetActive(false);
        playerAttak[2].SetActive(false);
        playerAttak[3].SetActive(false);
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
