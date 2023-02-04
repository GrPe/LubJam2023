using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public float Power = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var rat = collision.gameObject.GetComponent<RatMovement>();
        rat.SlowHimDown(Power);
    }
}
