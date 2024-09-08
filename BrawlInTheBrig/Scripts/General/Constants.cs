namespace BrawlInTheBrig.Scripts.General;

public enum EnemyAnimationType
{
    Idle,
    Move,
    Attack,
    TakeHit,
    Death
}

public enum PlayerAnimationType
{
    Idle,
    Move,
    Dash
}

public enum InputType
{
    MoveLeft,
    MoveRight,
    MoveForward,
    MoveBackward,
    Dash
}

public enum NotificationType
{
    StateEnable = 5001,
    StateDisable = 5002
}