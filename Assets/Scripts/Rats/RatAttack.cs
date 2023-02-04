using UnityEngine;

public class RatAttack : MonoBehaviour
{
    public float AttackDistance;
    public int Damage = 1;
    public float AttackColdown;

    private float _lastAttackTime = 0f;
    private RatMovement _movement;

    void Start()
    {
        _movement = GetComponent<RatMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        Debug.LogWarning($"{_movement.Agent.remainingDistance}:{_movement.Agent.isStopped}");

        TryAttack();
    }

    public void TryAttack()
    {
        if (_movement.Agent.remainingDistance >= AttackDistance)
        {
            _movement.Agent.isStopped = false;
            return;
        }

        _movement.Agent.isStopped = true;

        if (_lastAttackTime + AttackColdown >= Time.time)
        {
            return;
        }

        var eatable = _movement.Target.gameObject.GetComponent<Eatable>();
        eatable.DealDamage(Damage);
        _lastAttackTime = Time.time;
    }
}
