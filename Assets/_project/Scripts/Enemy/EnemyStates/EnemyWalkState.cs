using UnityEngine;

public class EnemyWalkState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager m)
    {
        m.anim.SetBool("Walking", true);
    }

    public override void UpdateState(EnemyStateManager m)
    {
        if (m.target == null) return;

        Vector3 dir = (m.target.position - m.transform.position).normalized;
        m.controller.Move(dir * m.walkSpeed * Time.deltaTime);
        m.transform.rotation = Quaternion.LookRotation(dir);

        if (Vector3.Distance(m.transform.position, m.target.position) <= m.attackRange)
        {
            ExitState(m, m.FightIdle);
        }
    }

    void ExitState(EnemyStateManager m, EnemyBaseState next)
    {
        m.anim.SetBool("Walking", false);
        m.SwitchState(next);
    }
}