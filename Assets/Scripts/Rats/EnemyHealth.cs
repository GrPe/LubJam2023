using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private ScoresController scoresController;

    [SerializeField] private RatGenerator ratGenerator;

    private void Awake()
    {
        ratGenerator = FindObjectOfType<RatGenerator>();
        scoresController = ratGenerator.GetScoresController();
    }

    public void DealDamage(int damage)
    {
        if (health - damage <= 0)
        {            
            if(ratGenerator != null)
            {
                ratGenerator.RatKilled();
            }
            scoresController.SetScores(health);
            Destroy(this.gameObject);
        }
        else
        {
            health -= damage;
        }
    }

    public void SetScoresController(ScoresController newScoresController)
    {
        this.scoresController = newScoresController;
    }
}
