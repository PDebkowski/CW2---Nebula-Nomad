using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [HideInInspector] public Animator anim;
    [HideInInspector] public CharacterController controller;

    [HideInInspector] public EnemyBaseState currentState;

    public EnemyWalkState Walk = new EnemyWalkState();
    public EnemySneakState Sneak = new EnemySneakState();
    public EnemyRestState Rest = new EnemyRestState();
    public EnemyFightIdleState FightIdle = new EnemyFightIdleState();
    public EnemyAttackState Attack = new EnemyAttackState();
    public EnemyTakeDamageState TakeDamage = new EnemyTakeDamageState();
    public EnemyDieState Die = new EnemyDieState();

    public Transform target;
    public float walkSpeed = 3f;
    public float sneakSpeed = 1.5f;
    public float restDuration = 5f;
    public float attackRange = 2f;

    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        SwitchState(Rest);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(EnemyBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

    public void TriggerAttack() => SwitchState(Attack);
    public void TriggerTakeDamage() => SwitchState(TakeDamage);
    public void TriggerDie() => SwitchState(Die);
    public void TriggerSneak() => SwitchState(Sneak);
    public void TriggerWalk() => SwitchState(Walk);
    public void TriggerRest() => SwitchState(Rest);
    public void TriggerFightIdle() => SwitchState(FightIdle);
}