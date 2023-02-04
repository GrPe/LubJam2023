using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerAttack : MonoBehaviour
{
    [SerializeField] private GameObject projectilePref=null;
    [SerializeField] private Transform spawnpoint=null;
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private Vector2 spotSize =Vector2.one;
    [SerializeField] private LayerMask spotLayer= new LayerMask();
    [SerializeField] private Collider2D spottedEnemie;

    private float timer=0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2)
        {
            spawnpoint.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        SearchAndShootEnemy();
    }

    private void SearchAndShootEnemy()
    {
        spottedEnemie = Physics2D.OverlapBox(transform.position, spotSize, 0, spotLayer);
        if(spottedEnemie != null && timer>=fireRate)
        {
            spottedEnemie.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth);

            //Quaternion targetRotation = Quaternion.LookRotation(spottedEnemie.transform.position);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 5 * Time.deltaTime);

            //Quaternion projectileRotation = Quaternion.LookRotation(spottedEnemie.transform.position - transform.position);

            GameObject projectileInstance = Instantiate(projectilePref, spawnpoint.position,transform.rotation);
            projectileInstance.GetComponent<Projectile>().SetDmg(1);
            projectileInstance.GetComponent<Projectile>().SetTarget(spottedEnemie.transform);
            timer = 0;
            spawnpoint.gameObject.GetComponent<SpriteRenderer>().enabled= false;
        }

    }
}
