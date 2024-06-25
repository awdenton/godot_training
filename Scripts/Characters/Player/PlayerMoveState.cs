using Godot;
using System;
using BrawlInTheBrig.Scripts.General;
using static Godot.TextServer;

public partial class PlayerMoveState : PlayerBaseState
{
    /// <inheritdoc />
    public override void _PhysicsProcess(double delta)
    {
        if (PlayerNode.Direction == Vector2.Zero)
        {
            PlayerNode.StateMachine.SwitchState<PlayerIdleState>();
            return;
        }

        PlayerNode.Velocity = new(PlayerNode.Direction.X, 0, PlayerNode.Direction.Y);
        PlayerNode.Velocity *= 5;

        PlayerNode.MoveAndSlide();
        PlayerNode.FlipHorizontal();
    }

    /// <inheritdoc />
    public override void _Notification(int what)
    {
        base._Notification(what);
        switch (what)
        {
            case Constants.StateEnable:
                PlayerNode.AnimationPlayer.Play(Constants.AnimMove);
                EnableState();
                break;
            case Constants.StateDisable:
                DisableState();
                break;
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
}
