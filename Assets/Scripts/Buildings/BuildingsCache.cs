using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuildingsCache : MonoBehaviour
{
    public Eatable[] BuildingsToEat = Array.Empty<Eatable>();
    public Decoy[] Decoys = Array.Empty<Decoy>();

    private void Start()
    {
        RefreshCache();
    }

    private void Update()
    {

    }

    public void RefreshCache()
    {
        BuildingsToEat = FindObjectsOfType<Eatable>().Where(x => x != null && !x.IsAte()).ToArray();
        var tempDecoys = new List<Decoy>();
        foreach(var b in BuildingsToEat)
        {
            if(b.TryGetComponent<Decoy>(out Decoy decoy))
            {
                tempDecoys.Add(decoy);
            }
        }

        Decoys = tempDecoys.ToArray();
    }
}