using Godot;
using BrawlInTheBrig.Scripts.General;

public partial class PlayerIdleState : PlayerBaseState
{
    /// <inheritdoc />
    public override void _PhysicsProcess(double delta)
    {
        if (PlayerNode.Direction != Vector2.Zero)
        {
            PlayerNode.StateMachine.SwitchState<PlayerMoveState>();
        }
    }

    /// <inheritdoc />
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(Constants.InputDash))
        {
            PlayerNode.StateMachine.SwitchState<PlayerDashState>();
        }
    }

    /// <inheritdoc />
    protected override void HandleStateEnable()
    {
        PlayerNode.AnimationPlayer.Play(Constants.AnimIdle);
        SetStateProcess(true);
    }
}