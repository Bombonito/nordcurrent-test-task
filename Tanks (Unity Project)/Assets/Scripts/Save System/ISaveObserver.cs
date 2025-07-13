namespace Save_System
{
    public interface ISaveObserver<T>
    {
        void Add(T saveWriter);
        void Remove(T saveWriter);
    }
}