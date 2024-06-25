using Godot;
using System;
using System.Linq;
using BrawlInTheBrig.Scripts.General;

public partial class StateMachine : Node
{
    [Export]
    private Node _currentState;
    [Export]
    private Node[] _states;

    /// <inheritdoc />
    public override void _Ready()
    {
        _currentState.Notification(Constants.StateEnable);
    }

    public void SwitchState<T>()
    {
        var newState = _states.FirstOrDefault(state => state is T);
        if (newState is null) return;
        
        _currentState.Notification(Constants.StateDisable);
        _currentState = newState;
        _currentState?.Notification(Constants.StateEnable);
    }
}
