using UnityEngine;

public class RatGenerator : MonoBehaviour
{
    public GameObject[] RatsPrefabs;
    public GameObject[] Lairs;
    public GameObject TheGreatRatKing;
    public PlaceBuildings PlaceBuildings;
    public ScoresController scoresController;

    [SerializeField] private float _nextPhaseTime = 0;

    [SerializeField] private float _preparationTime = 10f;
    [SerializeField] private float _attackTime = 4f;

    [SerializeField] private int _phaseNumber = 0;
    [SerializeField] private int _szczurCount = 0;
    [SerializeField] private int _currentSubphase = 0;

    [SerializeField] private int _targetSubphases = 0;
    private bool _attackPhase = false;

    private void Start()
    {
        _nextPhaseTime += Time.time + _attackTime;
    }

    private void Update()
    {
        if (_nextPhaseTime <= Time.time && _attackPhase == false)
        {
            _currentSubphase = 1;
            _targetSubphases = Random.Range(4, 6 + _phaseNumber);
            _attackPhase = true;
            _phaseNumber++;
        }
        else if (_nextPhaseTime <= Time.time)
        {
            if (_currentSubphase > _targetSubphases)
            {
                _nextPhaseTime = Time.time + _preparationTime;
                _attackPhase = false;
                return;
            }

            var rats = Random.Range(4 + _phaseNumber + _currentSubphase / 2, 7 + _phaseNumber * 2 + _currentSubphase);
            for (var x = 0; x < rats; x++)
            {
                var lair = Random.Range(0, Lairs.Length);
                Instantiate(RatsPrefabs[x % RatsPrefabs.Length], Lairs[lair].transform.position, Quaternion.Euler(0, 0, 0), transform);
            }

            if (_currentSubphase == _targetSubphases && _phaseNumber % 2 == 0) //The rat king!
            {
                var kingLair = Random.Range(0, Lairs.Length);
                var king = Instantiate(TheGreatRatKing, Lairs[kingLair].transform.position, Quaternion.Euler(0, 0, 0), transform);
                king.GetComponent<EnemyHealth>().DealDamage(-(_phaseNumber * Random.Range(1, 3)));
            }

            _nextPhaseTime = Time.time + _attackTime;
            _currentSubphase++;
        }
    }

    public ScoresController GetScoresController()
    {
        return scoresController;
    }
}
