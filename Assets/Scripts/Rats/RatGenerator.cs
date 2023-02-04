using UnityEngine;

public class RatGenerator : MonoBehaviour
{
    public GameObject[] RatsPrefabs;
    public GameObject[] Lairs;
    public PlaceBuildings PlaceBuildings;

    private float _nextSpawnTime = 0;

    private void Start()
    {
        RatRush(3, 6);
        _nextSpawnTime += Time.time + Random.Range(1, 3);
    }

    private void Update()
    {
        if(_nextSpawnTime <= Time.time)
        {
            RatRush(3, 6);
            _nextSpawnTime = Time.time + Random.Range(1, 3);
        }
    }

    private int RatRush(int min, int max)
    {
        var ratsCount = (int)Random.Range(min, max);

        for (var x = 0; x < ratsCount; x++)
        {
            var lair = (int)Random.Range(0, Lairs.Length);
            Instantiate(RatsPrefabs[x % RatsPrefabs.Length], Lairs[lair].transform.position, Quaternion.Euler(0, 0, 0), transform);
        }

        return ratsCount;
    }

    public void RatKilled()
    {
        PlaceBuildings.Coins += 2;
    }
}
