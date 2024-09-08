using Godot;
using BrawlInTheBrig.Scripts.General;

public partial class Player : CharacterBase
{
    /// <inheritdoc />
    public override void _Input(InputEvent @event)
    {
        Direction = Input.GetVector($"{InputType.MoveLeft}"
            , $"{InputType.MoveRight}"
            , $"{InputType.MoveForward}"
            , $"{InputType.MoveBackward}");
    }
}
