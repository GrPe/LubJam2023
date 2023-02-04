using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    public int _durability = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsAte() => _durability <= 0;

    public void DealDamage(int damage)
    {
        _durability -= damage;

        if(_durability <= 0)
        {
            FindObjectOfType<BuildingsCache>().RefreshCache();
            Debug.LogWarning("building consumed");
            Destroy(gameObject);
        }
    }
}
