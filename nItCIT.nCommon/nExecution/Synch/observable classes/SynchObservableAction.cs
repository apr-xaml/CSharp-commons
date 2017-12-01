using System;

namespace nIt.nCommon.nExecution
{
    public class SynchObservableAction : SynchAction, ISynchObservableAction
    {

        Action _oxBodyAction;
        Action<IPropertyChanged<ISynchAction>> _subscribers;
        private IXor2<IPropertyDescription<ISynchAction, bool>, IPropertyDescriptionChain<ISynchAction, bool>, IPropertyOrChainDescription> _Cached_IsExecutingPropertyDescription;

        ISynchAction IObservableObject<ISynchAction>.Insider
          => this;

        IObservableObject IAnd<IObservableObject, ISynchAction>.A
           => this;

        ISynchAction IAnd<IObservableObject, ISynchAction>.B
           => this;

        public SynchObservableAction(Action oxBodyAction, IObservableProperty<bool> isAllowedObservable, string commandName)
            : base(oxBodyAction, isAllowedObservable.GetValue, commandName)
        {
            _oxBodyAction = oxBodyAction;
            _Cached_IsExecutingPropertyDescription = PropertyDescription.FromExpression<ISynchAction, bool>(x => x.IsExecuting);
        }


        protected override void __BeforeExecution()
        {
            base.__BeforeExecution();

            var propChanged = new PropertyChanged<ISynchAction, bool>(_Cached_IsExecutingPropertyDescription, oldValue: false, newValue: true);
            _subscribers?.Invoke(propChanged);
        }

        protected override void __AfterExecution()
        {
            base.__AfterExecution();

            var propChanged = new PropertyChanged<ISynchAction, bool>(_Cached_IsExecutingPropertyDescription, oldValue: true, newValue: false);
            _subscribers?.Invoke(propChanged);
        }

        public ISubscription Subscribe(Action<IPropertyChanged<ISynchAction>> subscriber)
        {
            _subscribers += subscriber;
            return new Subscription(() => _subscribers -= subscriber);
        }

        public ISubscription Subscribe(Action<IPropertyChanged> subscriber)
        {
            _subscribers += subscriber;
            return new Subscription(() => _subscribers -= subscriber);
        }
    }
}
