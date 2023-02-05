using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 1;
    [SerializeField] private ScoresController scoresController;

    [SerializeField] private RatGenerator ratGenerator;
    [SerializeField] private TMP_Text hptext;


    private void Awake()
    {
        hptext.text= health.ToString();
        ratGenerator = FindObjectOfType<RatGenerator>();
        scoresController = ratGenerator.GetScoresController();
    }

    public void DealDamage(int damage)
    {
        if (health - damage <= 0)
        {            
            if(ratGenerator != null)
            {
                scoresController.SetScores(health);
            }
            Destroy(this.gameObject);
        }
        else
        {
            health -= damage;
            hptext.text = health.ToString();
        }
    }

    public void SetScoresController(ScoresController newScoresController)
    {
        this.scoresController = newScoresController;
    }
}
