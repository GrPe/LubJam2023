using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    public int _durability = 3;
    public BuildingsCache BuildingsCache;

    public bool IsAte() => _durability <= 0;

    public void DealDamage(int damage)
    {
        _durability -= damage;

        if(_durability == 0)
        {
            if(BuildingsCache != null)
            {
                BuildingsCache.RemoveObject(gameObject);
            }
            Destroy(gameObject);
        }
    }
}
