using Godot;
using BrawlInTheBrig.Scripts.General;

public partial class PlayerIdleState : PlayerState
{
    /// <inheritdoc />
    public override void _PhysicsProcess(double delta)
    {
        if (CharacterNode.Direction != Vector2.Zero)
        {
            CharacterNode.StateMachine.SwitchState<PlayerMoveState>();
        }
    }

    /// <inheritdoc />
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed($"{InputType.Dash}"))
        {
            CharacterNode.StateMachine.SwitchState<PlayerDashState>();
        }
    }

    /// <inheritdoc />
    protected override void HandleStateEnable()
    {
        CharacterNode.AnimationPlayer.Play($"{PlayerAnimationType.Idle}");
    }
}