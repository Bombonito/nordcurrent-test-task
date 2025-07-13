namespace Utilities.Handler
{
    public abstract class BaseHandler : IHandler
    {
        public IHandler Next { get; private set; }

        public IHandler SetNext(IHandler next)
        {
            Next = next;
            return this;
        }

        public void Handle(object target)
        {
            if (CanHandleInternal(target))
                HandleInternal(target);
            else
                Next?.Handle(target);
        }

        protected abstract void HandleInternal(object target);
        protected abstract bool CanHandleInternal(object target);
    }
}