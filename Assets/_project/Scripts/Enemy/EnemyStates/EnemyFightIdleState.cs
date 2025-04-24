using UnityEngine;

public class EnemyFightIdleState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager m)
    {
        m.anim.SetBool("FightIdle", true);
    }

    public override void UpdateState(EnemyStateManager m)
    {
        if (m.target == null) return;

        float dist = Vector3.Distance(m.transform.position, m.target.position);
        if (dist <= m.attackRange)
        {
            ExitState(m, m.Attack);
        }
        else
        {
            ExitState(m, m.Walk);
        }
    }

    void ExitState(EnemyStateManager m, EnemyBaseState next)
    {
        m.anim.SetBool("FightIdle", false);
        m.SwitchState(next);
    }
}