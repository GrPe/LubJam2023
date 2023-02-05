using UnityEngine;

public class RatAttack : MonoBehaviour
{
    public Animator AttackAnimation;
    public float AttackDistance;
    public int Damage = 1;
    public float AttackColdown;

    private float _lastAttackTime = 0f;
    private RatMovement _movement;
    [SerializeField] private float _firstAttackDelay = 0.2f;

    void Start()
    {
        _movement = GetComponent<RatMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        TryAttack();
    }

    public void TryAttack()
    {
        if(_movement.Target == null)
        {
            return;
        }

        if (_movement.Agent.remainingDistance >= AttackDistance)
        {
            _movement.Agent.isStopped = false;
            return;
        }

        if(!_movement.Agent.isStopped)
        {
            _lastAttackTime = Time.time + _firstAttackDelay;
            _movement.Agent.isStopped = true;
        }

        if (_lastAttackTime + AttackColdown >= Time.time)
        {
            return;
        }

        //AttackAnimation.Play("RatIdleAnimation");
        //AttackAnimation.Play("RatAttackAnimation");
        var eatable = _movement.Target.gameObject.GetComponent<Eatable>();
        eatable.DealDamage(Damage);
        _lastAttackTime = Time.time;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, AttackDistance);
    }
}
