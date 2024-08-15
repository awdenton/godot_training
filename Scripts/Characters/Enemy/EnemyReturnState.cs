using BrawlInTheBrig.Scripts.General;
using Godot;

public partial class EnemyReturnState : EnemyState
{
    private Vector3 _destination;

    /// <inheritdoc />
    public override void _Ready()
    {
        base._Ready();

        var localPosition = CharacterNode.PathNode.Curve.GetPointPosition(0);
        var globalPosition = CharacterNode.PathNode.GlobalPosition;
        _destination = localPosition + globalPosition;
    }

    /// <inheritdoc />
    protected override void HandleStateEnable()
    {
        CharacterNode.AnimationPlayer.Play($"{EnemyAnimationType.Move}");
    }

    /// <inheritdoc />
    public override void _PhysicsProcess(double delta)
    {
        if (CharacterNode.GlobalPosition == _destination)
        {
            return;
        }
        GD.Print($"{CharacterNode.GlobalPosition} - {_destination}");
        CharacterNode.Velocity = CharacterNode.GlobalPosition.DirectionTo(_destination);
        CharacterNode.MoveAndSlide();
    }
}
