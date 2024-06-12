using Godot;
using System;
using BrawlInTheBrig.Scripts.General;

public partial class Player : CharacterBody3D
{
    private AnimationPlayer _animationPlayer;
    private Sprite3D _sprite3D;
    private Vector2 _direction;

    /// <inheritdoc />
    public override void _Ready()
    {
        _animationPlayer = (AnimationPlayer)GetNode("AnimationPlayer");
        _sprite3D = (Sprite3D)GetNode("Sprite3D");

        _animationPlayer.Play(Constants.AnimIdle);
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
        
        _animationPlayer.Play(_direction == Vector2.Zero
            ? Constants.AnimIdle
            : Constants.AnimMove);
    }

    private void FlipHorizontal()
    {
        if (Velocity.X == 0) return;
        _sprite3D.FlipH = _direction.X < 0;
    }
}
