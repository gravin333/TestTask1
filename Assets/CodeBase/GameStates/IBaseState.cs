namespace CodeBase.GameStates
{
    public interface IBaseState : IExitableState
    {
        void Enter();
    }
}