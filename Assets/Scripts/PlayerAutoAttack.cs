using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoAttack : MonoBehaviour
{
    [SerializeField] private int dmg = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            enemy.DealDamage(dmg);
            Debug.Log("EEEEEEEEEEEEEEE");
        }
    }

}
