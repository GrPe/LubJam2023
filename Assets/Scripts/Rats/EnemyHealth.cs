using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 1;


    public void DealDamage(int damage)
    {
        if (health - damage <= 0)
        {
            var ratGenerator = FindObjectOfType<RatGenerator>();
            if(ratGenerator != null)
            {
                ratGenerator.RatKilled();
            }
            Destroy(this.gameObject);
        }
        else
        {
            health -= damage;
        }
    }
}
