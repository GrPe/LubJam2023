using UnityEngine;

public class RatGenerator : MonoBehaviour
{
    public GameObject[] RatsPrefabs;
    public GameObject[] Lairs;
    public PlaceBuildings PlaceBuildings;
    public ScoresController scoresController;

    [SerializeField] private float _nextSpawnTime = 0;
    [SerializeField] private float timePassed = 1;

    private const float MinTime = 5;
    private const float MaxTime = 15;

    private void Start()
    {
        RatRush(2, 4);
        _nextSpawnTime += Time.time + Random.Range(1, 3);
    }

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (_nextSpawnTime <= Time.time)
        {
            RatRush(1, 4);
            _nextSpawnTime = 
                Time.time + Random.Range(MinTime / Mathf.Max(1, timePassed / 60), MaxTime / Mathf.Max(1, timePassed / 60));
        }
    }

    private int RatRush(int min, int max)
    {
        var ratsCount = (int)Random.Range(min, max);

        for (var x = 0; x < ratsCount; x++)
        {
            var lair = (int)Random.Range(0, Lairs.Length);
           //GameObject newRats = 
                Instantiate(RatsPrefabs[x % RatsPrefabs.Length], Lairs[lair].transform.position, Quaternion.Euler(0, 0, 0), transform);
            //newRats.gameObject.GetComponent<EnemyHealth>().SetScoresController(scoresController);
        }

        return ratsCount;
    }

    public ScoresController GetScoresController()
    {
        return scoresController;
    }
}
