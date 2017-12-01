using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{


    static public class ObservableProperty
    {
        static public IObservableProperty<TValue> OfNotifier<TOwner, TValue>(TOwner owner, Expression<Func<TOwner, TValue>> exProperty)
            where TOwner : class, IObservableObject<TOwner>
        {
            var propertyDescription = PropertyDescription.FromExpression(exProperty);
            return new ObservableProperty<TOwner, TValue>(propertyDescription, owner);
        }
    }

    public class ObservableProperty<TOwner, TValue> : IObservableProperty<TValue>
        where TOwner : class, IObservableObject<TOwner>
    {
        private readonly TOwner _owner;
        private readonly IXor2<IPropertyDescription<TOwner, TValue>, IPropertyDescriptionChain<TOwner, TValue>> _propertyDescription;

        Action<IValueChanged<TValue>> _listeners;
        private readonly ISubscription _mySubscription;

        public ObservableProperty(IXor2<IPropertyDescription<TOwner, TValue>, IPropertyDescriptionChain<TOwner, TValue>> propertyDescription, TOwner owner)
        {
            _owner = owner;
            _propertyDescription = propertyDescription;
            _mySubscription = _owner.Subscribe(_Listen);
        }

        private void _Listen(IPropertyChanged<TOwner> obj)
        {

            var propComparer = PropertyDescriptionComparer.Instance;
            var chainComparer = PropertyDescriptionChainComparerWithReason.Instance;
            var comp = Xor2<IPropertyDescription, IPropertyDescriptionChain>.Comparer(PropertyDescriptionComparer.Instance, chainComparer);

            if (comp.Equals(_propertyDescription, obj.PropertyDescription))
            {
                _listeners?.Invoke((IValueChanged<TValue>)obj);
            }
        }

        public ISubscription AddSubscribtion(Action<IValueChanged<TValue>> handler)
        {
            return new Subscription(() => _listeners -= handler);
        }

        public void Dispose()
        {
            _mySubscription.Dispose();
        }

        public TValue GetValue()
        {
            return ValueOf.Property(_propertyDescription, _owner);
        }
    }
}
