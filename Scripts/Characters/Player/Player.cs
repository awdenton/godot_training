using Godot;
using System;
using BrawlInTheBrig.Scripts.General;

public partial class Player : CharacterBody3D
{
    private Vector2 _direction;

    private AnimationPlayer _animationPlayer;
    [Export]
    public AnimationPlayer AnimationPlayer
    {
        get => _animationPlayer;
        set
        {
            GD.Print("Player AnimationPlayer setter");
            _animationPlayer = value;
        }
    }
    public Sprite3D Sprite3D;

    public Player() : base()
    {
        GD.Print("Player constructor");
    }

    /// <inheritdoc />
    public override void _EnterTree()
    {
        GD.Print("Player _EnterTree");
        AnimationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
        Sprite3D = (Sprite3D)GetNode("Sprite3D");
    }

    public override void _Ready()
    {
        GD.Print("Player _Ready");
    }

    /// <inheritdoc />
    public override void _PhysicsProcess(double delta)
    {
        Velocity = new(_direction.X, 0, _direction.Y);
        Velocity *= 5;
        
        MoveAndSlide();
        FlipHorizontal();
    }

    /// <inheritdoc />
    public override void _Input(InputEvent @event)
    {
        _direction = Input.GetVector(Constants.InputMoveLeft
            , Constants.InputMoveRight
            , Constants.InputMoveForward
            , Constants.InputMoveBackward);
    }

    private void FlipHorizontal()
    {
        if (Velocity.X == 0) return;
        Sprite3D.FlipH = _direction.X < 0;
    }
}
