using Godot;
using System;
using BrawlInTheBrig.Scripts.General;

public partial class PlayerDashState : PlayerBaseState
{
    private Timer _dashTimerNode;

    /// <inheritdoc />
    public override void _Ready()
    {
        _dashTimerNode = (Timer)GetNode("Timer");
        _dashTimerNode.Timeout += HandleDashTimeout;
    }

    /// <inheritdoc />
    public override void _Notification(int what)
    {
        base._Notification(what);
        switch (what)
        {
            case Constants.StateEnable:
                PlayerNode.AnimationPlayer.Play(Constants.AnimDash);
                _dashTimerNode.Start();
                EnableState();
                break;
            case Constants.StateDisable:
                DisableState();
                break;
        }
    }

    private void HandleDashTimeout()
    {
        PlayerNode.StateMachine.SwitchState<PlayerIdleState>();
    }
}
