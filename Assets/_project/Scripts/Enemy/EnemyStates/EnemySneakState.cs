using UnityEngine;

public class EnemySneakState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager m)
    {
        m.anim.SetBool("Sneaking", true);
    }

    public override void UpdateState(EnemyStateManager m)
    {
        if (m.target == null) return;

        Vector3 dir = (m.target.position - m.transform.position).normalized;
        m.controller.Move(dir * m.sneakSpeed * Time.deltaTime);
        m.transform.rotation = Quaternion.LookRotation(dir);

        if (Vector3.Distance(m.transform.position, m.target.position) <= m.attackRange)
        {
            ExitState(m, m.FightIdle);
        }
    }

    void ExitState(EnemyStateManager m, EnemyBaseState next)
    {
        m.anim.SetBool("Sneaking", false);
        m.SwitchState(next);
    }
}