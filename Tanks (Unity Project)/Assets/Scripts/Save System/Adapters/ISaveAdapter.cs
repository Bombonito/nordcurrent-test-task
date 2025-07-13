using System.Collections;

namespace Save_System.Adapters
{
    public interface ISaveAdapter<T>
    {
        T Extract();
        IEnumerator ApplyCoroutine(T saveData);
    }
}