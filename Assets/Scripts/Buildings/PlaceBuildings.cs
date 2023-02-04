using System.Linq;
using UnityEngine;

public class PlaceBuildings : MonoBehaviour
{
    public Transform Player;
    public GameObject AttackTower;
    public GameObject SloweringTower;
    public GameObject DecoyTower;
    public float Distance = 3f;

    void Start()
    {
        if (Player == null)
        {
            Player = FindObjectOfType<Player>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Attack tower
        {
            if (CanPlaceTower())
            {
                var tower = Instantiate(AttackTower, Player.transform.position, Quaternion.Euler(0, 0, 0));
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) // slowering tower
        {
            if (CanPlaceTower())
            {
                var tower = Instantiate(SloweringTower, Player.transform.position, Quaternion.Euler(0, 0, 0));
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) // decoy tower
        {
            if (CanPlaceTower())
            {
                var tower = Instantiate(DecoyTower, Player.transform.position, Quaternion.Euler(0, 0, 0));
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
}
