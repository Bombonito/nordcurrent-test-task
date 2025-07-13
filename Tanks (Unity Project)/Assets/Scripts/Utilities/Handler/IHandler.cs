namespace Utilities.Handler
{
    public interface IHandler
    {
        IHandler Next { get; }
        IHandler SetNext(IHandler next);
        void Handle(object target);
    }
}