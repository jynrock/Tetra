public interface ISubscribable<T>
{
    void Subscribe(IListener<T> listener);

    void Unsubscribe(IListener<T> listener);

    void Raise(T data);
}
