using Godot;
using BrawlInTheBrig.Scripts.General;

public partial class PlayerMoveState : PlayerState
{
    private const int MoveSpeed = 5;

    /// <inheritdoc />
    public override void _PhysicsProcess(double delta)
    {
        if (CharacterNode.Direction == Vector2.Zero)
        {
            CharacterNode.Velocity = Vector3.Zero;
            CharacterNode.StateMachine.SwitchState<PlayerIdleState>();
            return;
        }

        CharacterNode.Velocity = new Vector3(CharacterNode.Direction.X, 0, CharacterNode.Direction.Y);
        CharacterNode.Velocity *= MoveSpeed;

        CharacterNode.MoveAndSlide();
        CharacterNode.FlipHorizontal();
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
        CharacterNode.AnimationPlayer.Play($"{PlayerAnimationType.Move}");
    }
}
