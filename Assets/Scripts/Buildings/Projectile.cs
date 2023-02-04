using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private NavMeshAgent proAgent = null;
    private Transform target = null;
    private int dmg = 1;

    //float time =0;

    private void Start()
    {
        proAgent.updateRotation = false;
    }

    void Update()
    {
        //time+= Time.deltaTime;
        if (target != null)
        {
            proAgent.SetDestination(target.position);
        }
        if (target==null)//time >= 5 || 
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemyhealth)){
            Debug.Log("EEEEEEEEEEEEEEE");
            enemyhealth.DealDamage(dmg);
            Destroy(this.gameObject);
        }
    }

    public void SetDmg(int newDmg)
    {
        dmg=newDmg;
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
