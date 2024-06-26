using Godot;
using BrawlInTheBrig.Scripts.General;

public partial class Player : CharacterBody3D
{
    public Vector2 Direction { get; private set; }

    public AnimationPlayer AnimationPlayer { get; private set; }
    public Sprite3D Sprite3D { get; private set; }
    public StateMachine StateMachine { get; private set; }

    /// <inheritdoc />
    public override void _EnterTree()
    {
        AnimationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
        Sprite3D = (Sprite3D)GetNode("Sprite3D");
        StateMachine = (StateMachine)GetNode("StateMachine");
    }

    /// <inheritdoc />
    public override void _Input(InputEvent @event)
    {
        Direction = Input.GetVector(Constants.InputMoveLeft
            , Constants.InputMoveRight
            , Constants.InputMoveForward
            , Constants.InputMoveBackward);
    }

    public void FlipHorizontal()
    {
        if (Velocity.X == 0) return;
        Sprite3D.FlipH = Velocity.X < 0;
    }
}
