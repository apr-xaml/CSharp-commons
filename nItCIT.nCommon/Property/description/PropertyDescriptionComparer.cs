using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nIt.nCommon
{
    public class PropertyDescriptionComparer : IEqualityComparerWithReason<IPropertyDescription, PropertyDescriptionsAreDifferentReasonEnum>
    {
        static public readonly PropertyDescriptionComparer Instance = new PropertyDescriptionComparer();

        private PropertyDescriptionComparer()
        {

        }

        public EqualityResult<IPropertyDescription, PropertyDescriptionsAreDifferentReasonEnum> AreEqual(IPropertyDescription first, IPropertyDescription second)
        {
   
           
            if(first.AccessingType != second.AccessingType)
            {
                return PropertyDescriptionsAreDifferentReasonEnum.OwnerType;
            }

            if(first.ValueType.Extends(second.ValueType))
            {
                return PropertyDescriptionsAreDifferentReasonEnum.ValueType;
            }

            if(first.ShortName != second.ShortName)
            {
                return PropertyDescriptionsAreDifferentReasonEnum.ShortName;
            }

            return EqualityResult.Ok;
        }

        public bool Equals(IPropertyDescription x, IPropertyDescription y)
        {
            return AreEqual(x, y);
        }

        public int GetHashCode(IPropertyDescription obj)
            => HashCode.Of(obj.AccessingType, obj.ValueType, obj.ShortName);
        
    }



    public enum PropertyDescriptionsAreDifferentReasonEnum
    {
        //ExplicitInterface,
        OwnerType,
        ValueType,
        ShortName
    }
}