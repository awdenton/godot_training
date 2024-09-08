using Godot;

public abstract partial class CharacterBase : CharacterBody3D
{
    public Vector2 Direction { get; protected set; } = Vector2.Zero;

    public AnimationPlayer AnimationPlayer { get; protected set; }
    public Sprite3D Sprite3D { get; protected set; }
    public StateMachine StateMachine { get; protected set; }

    [Export] public Path3D PathNode { get; protected set; }

    /// <inheritdoc />
    public override void _EnterTree()
    {
        AnimationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
        Sprite3D = (Sprite3D)GetNode("Sprite3D");
        StateMachine = (StateMachine)GetNode("StateMachine");
    }

    public void FlipHorizontal()
    {
        if (Velocity.X == 0) return;
        Sprite3D.FlipH = Velocity.X < 0;
    }
}