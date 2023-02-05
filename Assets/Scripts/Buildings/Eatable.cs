using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    public int _durability = 3;
    public BuildingsCache BuildingsCache;
    public bool isHQ = false;
    public bool isEnemy = false;
    public PlayerHQHealthDisplay hQHealthDisplay;

    public bool IsAte() => _durability <= 0;

    public void DealDamage(int damage)
    {
        _durability -= damage;
        if(isHQ)
        {
            hQHealthDisplay.SetTMP_Text(_durability);
        }

        if(_durability == 0)
        {
            if(BuildingsCache != null)
            {
                BuildingsCache.RemoveObject(gameObject);
            }
            Destroy(gameObject);
        }
    }
    public int GetDurability() { return _durability; }
}
