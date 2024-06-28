using Godot;
using BrawlInTheBrig.Scripts.General;

public partial class PlayerDashState : PlayerState
{
    private Timer _dashTimerNode;

    private const int DashSpeed = 10;

    /// <inheritdoc />
    public override void _Ready()
    {
        _dashTimerNode = (Timer)GetNode("Timer");
        _dashTimerNode.Timeout += HandleDashTimeout;
    }

    /// <inheritdoc />
    public override void _PhysicsProcess(double delta)
    {
        CharacterNode.MoveAndSlide();
        CharacterNode.FlipHorizontal();
    }

    /// <inheritdoc />
    protected override void HandleStateEnable()
    {
        CharacterNode.AnimationPlayer.Play($"{PlayerAnimationType.Dash}");
        CharacterNode.Velocity = new Vector3(CharacterNode.Direction.X, 0, CharacterNode.Direction.Y);
        if (CharacterNode.Velocity == Vector3.Zero)
        {
            CharacterNode.Velocity = CharacterNode.Sprite3D.FlipH
                ? Vector3.Left
                : Vector3.Right;
        }
        CharacterNode.Velocity *= DashSpeed;
        _dashTimerNode.Start();
    }

    private void HandleDashTimeout()
    {
        CharacterNode.Velocity = Vector3.Zero;
        CharacterNode.StateMachine.SwitchState<PlayerIdleState>();
    }
}
