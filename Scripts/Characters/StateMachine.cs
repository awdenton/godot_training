using Godot;
using System.Linq;
using BrawlInTheBrig.Scripts.General;

public partial class StateMachine : Node
{
    [Export]
    private Node _currentState;
    private Node[] _states;

    /// <inheritdoc />
    public override void _EnterTree()
    {
        _states = GetChildren().ToArray();
    }

    /// <inheritdoc />
    public override void _Ready()
    {
        GD.Print(_currentState.GetType());
        _currentState.Notification((int)NotificationType.StateEnable);
    }

    public void SwitchState<T>()
    {
        GD.Print($"Changing state [{this.GetParent().GetType()}] [{typeof(T)}]");
        var newState = _states.FirstOrDefault(state => state is T);
        if (newState is null) return;
        
        _currentState.Notification((int)NotificationType.StateDisable);
        _currentState = newState;
        _currentState?.Notification((int)NotificationType.StateEnable);
    }
}
