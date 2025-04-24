using UnityEngine;

public class EnemyDieState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager m)
    {
        m.anim.SetTrigger("Die");
    }

    public override void UpdateState(EnemyStateManager m)
    {
        AnimatorStateInfo info = m.anim.GetCurrentAnimatorStateInfo(0);
        if (!m.anim.IsInTransition(0)
            && info.IsName("Die")
            && info.normalizedTime >= 1f)
        {
            Object.Destroy(m.gameObject);
        }
    }
}