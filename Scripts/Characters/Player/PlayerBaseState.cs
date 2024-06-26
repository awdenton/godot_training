using Godot;
using BrawlInTheBrig.Scripts.General;

public abstract partial class PlayerBaseState : Node
{
    protected Player PlayerNode;

    /// <inheritdoc />
    public override void _EnterTree()
    {
        PlayerNode = GetOwner<Player>();
        SetStateProcess(false);
    }

    /// <inheritdoc />
    public override void _Notification(int what)
    {
        base._Notification(what);
        switch (what)
        {
            case Constants.StateEnable:
                HandleStateEnable();
                break;
            case Constants.StateDisable:
                SetStateProcess(false);
                break;
        }
    }

    protected abstract void HandleStateEnable();

    protected void SetStateProcess(bool enable)
    {
        SetPhysicsProcess(enable);
        SetProcessInput(enable);
    }
}