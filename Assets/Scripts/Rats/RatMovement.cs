using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RatMovement : MonoBehaviour
{
    public Transform Target;
    public Transform Transform;
    public float AreaOfSight = 3;
    public float ThinkingTime = 1;

    public NavMeshAgent Agent;
    [SerializeField] private BuildingsCache _potentialMeals;
    private float _lastRething;

    // Start is called before the first frame update
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.updateRotation = false;
        Agent.updateUpAxis = false;
        Transform = transform;
        _potentialMeals = FindObjectOfType<BuildingsCache>();
        _lastRething = Time.time;
    }

    public void SlowHimDown(float power)
    {
        Agent.speed /= power;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target == null || Target.gameObject == null || Target.gameObject.IsDestroyed() || (_lastRething + ThinkingTime < Time.time))
        {
            if(_potentialMeals == null)
            {
                Debug.LogWarning("Rat is disconnected with BuildingsCache!!!!!!!!!");
                _potentialMeals = FindObjectOfType<BuildingsCache>();
            }

            _lastRething = Time.time;

            var meal = _potentialMeals
                .BuildingsToEat
                .Where(x => x != null)
                .FirstOrDefault(b => Vector3.Distance(transform.position, b.transform.position) <= AreaOfSight);

            if (meal != null)
            {
                SetDestination(meal.transform);
                return;
            }

            var nearestDecoy = _potentialMeals
                .Decoys
                .Where(x => x != null)
                .OrderBy(d => Vector3.Distance(Transform.position, d.transform.position))
                .FirstOrDefault();

            if (nearestDecoy != null)
            {
                SetDestination(nearestDecoy.transform);
                return;
            }
            else
            {
                var turnip = FindObjectOfType<Turnip>();
                if(turnip != null)
                {
                    SetDestination(turnip.transform);
                }
                return;
            }
        }
    }

    private void SetDestination(Transform destination)
    {
        Target = destination;
        Agent.SetDestination(destination.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, AreaOfSight);
    }
}
