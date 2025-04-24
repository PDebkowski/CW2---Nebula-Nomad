using UnityEngine;

public class EnemyTakeDamageState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager m)
    {
        m.anim.SetTrigger("TakeDamage");
    }

    public override void UpdateState(EnemyStateManager m)
    {
        AnimatorStateInfo info = m.anim.GetCurrentAnimatorStateInfo(0);
        if (!m.anim.IsInTransition(0)
            && info.IsName("TakeDamage")
            && info.normalizedTime >= 1f)
        {
            m.SwitchState(m.FightIdle);
        }
    }
}