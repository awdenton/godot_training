using Godot;
using System;
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
    public override void _Notification(int what)
    {
        base._Notification(what);
        switch (what)
        {
            case Constants.StateEnable:
                PlayerNode.AnimationPlayer.Play(Constants.AnimIdle);
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
