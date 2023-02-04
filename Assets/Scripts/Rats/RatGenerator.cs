using UnityEngine;

public class RatGenerator : MonoBehaviour
{
    public GameObject[] RatsPrefabs;
    public GameObject[] Lairs;

    private int CurrentNumberOfRats = 0;

    private void Start()
    {
        CurrentNumberOfRats += RatRush(4, 10);
    }

    private void Update()
    {
        if (CurrentNumberOfRats <= 0)
        {

        }
    }

    private int RatRush(int min, int max)
    {
        var lair = (int)Random.Range(0, Lairs.Length);

        var ratsCount = (int)Random.Range(min, max);

        for (var x = 0; x < ratsCount; x++)
        {
            Instantiate(RatsPrefabs[x % RatsPrefabs.Length], Lairs[lair].transform.position, Quaternion.Euler(0, 0, 0), transform);
        }

        return ratsCount;
    }

    public void RatKilled()
    {
        CurrentNumberOfRats--;
    }
}
