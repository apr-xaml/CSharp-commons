using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public class PropertyDescriptionChainComparerWithReason : IEqualityComparerWithReason<IPropertyDescriptionChain, PropertyDescriptionsAreDifferentReasonEnum>
    {
        private PropertyDescriptionChainComparerWithReason()
        {

        }
        public static PropertyDescriptionChainComparerWithReason Instance { get; } = new PropertyDescriptionChainComparerWithReason();

        public EqualityResult<IPropertyDescriptionChain, PropertyDescriptionsAreDifferentReasonEnum> AreEqual(IPropertyDescriptionChain a, IPropertyDescriptionChain b)
        {
            var firstNotEqual = Zip
                .TwoSequences(a.Nodes, b.Nodes)
                .Select(xPair => PropertyDescriptionComparer.Instance.AreEqual(xPair.A, xPair.B))
                .FirstOrDefault(x => !x);

            return (firstNotEqual == null) ?
                EqualityResult.Ok
                : new EqualityResult<IPropertyDescriptionChain, PropertyDescriptionsAreDifferentReasonEnum>(firstNotEqual.NotEqualReason.Value);
        }

        public bool Equals(IPropertyDescriptionChain x, IPropertyDescriptionChain y)
        {
            return Zip
                .TwoSequences(x.Nodes, y.Nodes)
                .All(xPair => PropertyDescriptionComparer.Instance.Equals(xPair.A, xPair.B));
        }

        public int GetHashCode(IPropertyDescriptionChain obj)
        {
            return obj.PathName.GetHashCode();
        }
    }
}
