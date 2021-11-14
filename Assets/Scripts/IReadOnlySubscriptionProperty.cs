using System;

namespace Tools
{
    public interface IReadOnlySubscriptionProperty<T>//подписываемся на изменение любого параметра:меню, скорость машинки, время суток в игре и тд, поэтому <T>
    { 
        T Value { get; }
        void SubscribeOnChange(Action<T> subscriptionAction);
        void UnSubscriptionOnChange(Action<T> unsubscriptionAction);
    } 
}

