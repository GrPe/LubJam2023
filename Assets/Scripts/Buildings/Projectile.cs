using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = null;
    [SerializeField] private NavMeshAgent proAgent = null;
    [SerializeField] private GameObject leaf;
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
            leaf.transform.RotateAround(leaf.transform.position,new Vector3(0,0,6),6f);
        }
        if (target==null)//time >= 5 || 
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemyhealth)){
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
