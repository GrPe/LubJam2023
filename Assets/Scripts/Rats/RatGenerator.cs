using UnityEngine;

public class RatGenerator : MonoBehaviour
{
    public GameObject[] RatsPrefabs;
    public GameObject[] Lairs;

    public int RatRush(int min, int max)
    {
        var lair = (int)Random.Range(0, Lairs.Length);

        var ratsCount = (int)Random.Range(min, max);

        for (var x = 0; x < ratsCount; x++)
        {
            Instantiate(RatsPrefabs[x % RatsPrefabs.Length], Lairs[lair].transform.position, Quaternion.Euler(0, 0, 0), transform);
        }

        return ratsCount;
    }
}
