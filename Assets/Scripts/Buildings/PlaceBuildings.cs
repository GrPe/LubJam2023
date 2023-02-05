using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaceBuildings : MonoBehaviour
{
    public Transform Player;
    public GameObject AttackTower;
    public GameObject SloweringTower;
    public GameObject DecoyTower;
    public float Distance = 3f;

    [SerializeField] private ScoresController ScoresController;

    private Dictionary<TowerType, int> TowerPrices = new Dictionary<TowerType, int>
    { 
        {TowerType.Attacking, 50 },
        {TowerType.Slowering, 20 },
        {TowerType.Decoy, 30 }
    };


    [SerializeField] private BuildingsCache buildingsCache;

    void Start()
    {
        if (Player == null)
        {
            Player = FindObjectOfType<Player>().transform;
        }

        if (buildingsCache == null)
        {
            buildingsCache = FindObjectOfType<BuildingsCache>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) // Attack tower
        {
            if (CanPlaceTower() && CanBuyTower(TowerType.Attacking))
            {
                var tower = Instantiate(AttackTower, Player.transform.position, Quaternion.Euler(0, 0, 0));
                tower.GetComponent<Eatable>().BuildingsCache = buildingsCache;
                buildingsCache.AddObject(tower);
                BuyTower(TowerType.Attacking);

            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) // slowering tower
        {
            if (CanPlaceTower() && CanBuyTower(TowerType.Slowering))
            {
                var tower = Instantiate(SloweringTower, Player.transform.position, Quaternion.Euler(0, 0, 0));
                buildingsCache.AddObject(tower);
                BuyTower(TowerType.Slowering);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) // decoy tower
        {
            if (CanPlaceTower() && CanBuyTower(TowerType.Decoy))
            {
                var tower = Instantiate(DecoyTower, Player.transform.position, Quaternion.Euler(0, 0, 0));
                tower.GetComponent<Eatable>().BuildingsCache = buildingsCache;
                buildingsCache.AddObject(tower);
                BuyTower(TowerType.Decoy);
            }
        }
    }

    public bool CanPlaceTower()
    {
        var towers = FindObjectsOfType<Building>();

        if (towers.Length == 0)
        {
            return true;
        }

        return !towers.Any(t => Vector3.Distance(Player.transform.position, t.transform.position) < Distance);
    }

    private bool CanBuyTower(TowerType type) => ScoresController.Scores > TowerPrices[type];

    private void BuyTower(TowerType type) => ScoresController.SetScores(-TowerPrices[type]);

    private enum TowerType
    {
        Attacking,
        Slowering,
        Decoy
    }

}
