using UnityEngine;

public class EnemyRestState : EnemyBaseState
{
    private float timer;

    public override void EnterState(EnemyStateManager m)
    {
        timer = 0f;
        m.anim.SetBool("Resting", true);
    }

    public override void UpdateState(EnemyStateManager m)
    {
        timer += Time.deltaTime;
        if (timer >= m.restDuration)
        {
            ExitState(m, m.FightIdle);
        }
    }

    void ExitState(EnemyStateManager m, EnemyBaseState next)
    {
        m.anim.SetBool("Resting", false);
        m.SwitchState(next);
    }
}