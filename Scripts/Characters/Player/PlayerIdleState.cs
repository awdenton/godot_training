using Godot;
using System;
using BrawlInTheBrig.Scripts.General;

public partial class PlayerIdleState : Node
{
    public PlayerIdleState() : base()
    {
        GD.Print("PlayerIdleState constructor");
    }


    /// <inheritdoc />
    public override void _EnterTree()
    {
        GD.Print("PlayerIdleState _EnterTree");
    }

    /// <inheritdoc />
    public override void _Ready()
    {
        GD.Print("PlayerIdleState _Ready");
        var characterNode = GetOwner<Player>();
        characterNode.AnimationPlayer.Play(Constants.AnimIdle);
    }
}
