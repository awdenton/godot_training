using Godot;
using BrawlInTheBrig.Scripts.General;

public partial class PlayerMoveState : PlayerBaseState
{
    /// <inheritdoc />
    public override void _PhysicsProcess(double delta)
    {
        if (PlayerNode.Direction == Vector2.Zero)
        {
            PlayerNode.Velocity = Vector3.Zero;
            PlayerNode.StateMachine.SwitchState<PlayerIdleState>();
            return;
        }

        PlayerNode.Velocity = new(PlayerNode.Direction.X, 0, PlayerNode.Direction.Y);
        PlayerNode.Velocity *= 5;

        PlayerNode.MoveAndSlide();
        PlayerNode.FlipHorizontal();
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
        PlayerNode.AnimationPlayer.Play(Constants.AnimMove);
        SetStateProcess(true);
    }
}
