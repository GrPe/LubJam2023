using System.Collections.Generic;
using UnityEngine;

public class BuildingsCache : MonoBehaviour
{
    public List<GameObject> BuildingsToEat = new();
    public List<GameObject> Decoys = new();

    [SerializeField] private RatGenerator RatGenerator;

    public void RemoveObject(GameObject go)
    {
        if(go.TryGetComponent<Decoy>(out var decoy))
        {
            Decoys.Remove(go);
        }

        if (go.TryGetComponent<Eatable>(out var eatable))
        {
            BuildingsToEat.Remove(go);
        }
    }

    public void AddObject(GameObject go)
    {
        if (go.TryGetComponent<Decoy>(out var decoy))
        {
            Decoys.Add(go);
        }

        if(go.TryGetComponent<Eatable>(out var eatable))
        {
            eatable._durability += (RatGenerator.CurrentPhase - 1) * 2;
            BuildingsToEat.Add(go);
        }
    }
}