using BrawlInTheBrig.Scripts.General;
using Godot;

public abstract partial class CharacterStateBase : Node 
{
    protected CharacterBase CharacterNode;

    /// <inheritdoc />
    public override void _EnterTree()
    {
        CharacterNode = GetOwner<CharacterBase>();
    }

    /// <inheritdoc />
    public override void _Ready()
    {
        SetStateProcess(false);
    }

    /// <summary>
    /// Handles the StateEnable notification
    /// </summary>
    protected virtual void HandleStateEnable() { }

    /// <summary>
    /// Handles the StateDisable notification
    /// </summary>
    protected virtual void HandleStateDisable() { }

    /// <inheritdoc />
    public override void _Notification(int what)
    {
        base._Notification(what);
        switch (what)
        {
            case (int)NotificationType.StateEnable:
                HandleStateEnable();
                SetStateProcess(true);
                break;
            case (int)NotificationType.StateDisable:
                HandleStateDisable();
                SetStateProcess(false);
                break;
        }
    }
    
    /// <summary>
    /// Calls SetPhysicsProcess and SetProcessInput with <paramref name="enable"/>
    /// </summary>
    /// <param name="enable">True to activate PhysicsProcess and ProcessInput, false to deactivate.</param>
    protected void SetStateProcess(bool enable)
    {
        SetPhysicsProcess(enable);
        SetProcessInput(enable);
    }
}