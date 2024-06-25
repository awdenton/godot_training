using Godot;
using System;

public abstract partial class PlayerBaseState : Node
{
    protected Player PlayerNode;

    /// <inheritdoc />
    public override void _EnterTree()
    {
        PlayerNode = GetOwner<Player>();
        DisableState();
    }

    protected void EnableState()
    {
        SetPhysicsProcess(true);
        SetProcessInput(true);
    }

    protected void DisableState()
    {
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }
}