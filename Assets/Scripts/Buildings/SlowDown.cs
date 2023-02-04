using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public float Power = 2f;
    public int Durability = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<RatMovement>(out var rat))
        {
            rat.SlowHimDown(Power);

            Durability--;

            if (Durability <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
