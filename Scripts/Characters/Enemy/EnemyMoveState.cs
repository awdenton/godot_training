using BrawlInTheBrig.Scripts.General;
using Godot;

public partial class EnemyMoveState : EnemyState
{

    /// <inheritdoc />
    public override void _PhysicsProcess(double delta)
    {
        if (CharacterNode.Direction == Vector2.Zero)
        {
            CharacterNode.Velocity = Vector3.Zero;
            CharacterNode.StateMachine.SwitchState<EnemyIdleState>();
            return;
        }

        CharacterNode.Velocity = new Vector3(CharacterNode.Direction.X, 0, CharacterNode.Direction.Y);
        CharacterNode.Velocity *= MoveSpeed;

        CharacterNode.MoveAndSlide();
        CharacterNode.FlipHorizontal();
    }

    /// <inheritdoc />
    protected override void HandleStateEnable()
    {
        CharacterNode.AnimationPlayer.Play($"{EnemyAnimationType.Move}");
    }
}
