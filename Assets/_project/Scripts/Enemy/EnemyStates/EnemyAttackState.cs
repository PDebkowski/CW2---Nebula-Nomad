using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private int index;

    public override void EnterState(EnemyStateManager m)
    {
        index = Random.Range(1, 6);
        m.anim.SetTrigger($"Attack{index}");
    }

    public override void UpdateState(EnemyStateManager m)
    {
        AnimatorStateInfo info = m.anim.GetCurrentAnimatorStateInfo(0);
        if (!m.anim.IsInTransition(0)
            && info.IsName($"Attack{index}")
            && info.normalizedTime >= 1f)
        {
            m.SwitchState(m.FightIdle);
        }
    }
}