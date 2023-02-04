using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
  [SerializeField] private int health = 1;


    public void DealDamage(int damage)
    {
        if(health-damage<=0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            health-= damage;
        }
    }
}
