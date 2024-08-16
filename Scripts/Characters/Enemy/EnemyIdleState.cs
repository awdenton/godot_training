using BrawlInTheBrig.Scripts.General;
using Godot;

public partial class EnemyIdleState : EnemyState
{
    /// <inheritdoc />
    public override void _PhysicsProcess(double delta)
    {
        if (CharacterNode.Direction != Vector2.Zero)
        {
            CharacterNode.StateMachine.SwitchState<EnemyMoveState>();
        }
    }

    /// <inheritdoc />
    protected override void HandleStateEnable()
    {
        CharacterNode.AnimationPlayer.Play($"{EnemyAnimationType.Idle}");
    }
}
