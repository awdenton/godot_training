using Godot;
using BrawlInTheBrig.Scripts.General;

public partial class PlayerDashState : PlayerBaseState
{
    private int _speed = 10;
    private Timer _dashTimerNode;

    /// <inheritdoc />
    public override void _Ready()
    {
        _dashTimerNode = (Timer)GetNode("Timer");
        _dashTimerNode.Timeout += HandleDashTimeout;
    }

    /// <inheritdoc />
    public override void _PhysicsProcess(double delta)
    {
        PlayerNode.MoveAndSlide();
        PlayerNode.FlipHorizontal();
    }

    /// <inheritdoc />
    protected override void HandleStateEnable()
    {
        PlayerNode.AnimationPlayer.Play(Constants.AnimDash);
        PlayerNode.Velocity = new(
            PlayerNode.Direction.X, 0, PlayerNode.Direction.Y
        );
        if (PlayerNode.Velocity == Vector3.Zero)
        {
            PlayerNode.Velocity = PlayerNode.Sprite3D.FlipH
                ? Vector3.Left
                : Vector3.Right;
        }
        PlayerNode.Velocity *= _speed;
        _dashTimerNode.Start();
        SetStateProcess(true);
    }

    private void HandleDashTimeout()
    {
        PlayerNode.Velocity = Vector3.Zero;
        PlayerNode.StateMachine.SwitchState<PlayerIdleState>();
    }
}
