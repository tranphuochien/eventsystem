using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Assets.Event
{
    [Serializable]
    public class Condition
    {
        public string _id;
        public int _value;
        public Comparator _comparator;

        public Condition(PreConditionRaw preConditionRaw)
        {
            this._id = preConditionRaw.flagId;
            this._value = preConditionRaw.value;
            this._comparator = ComparatorsManager.GetComparator(preConditionRaw.comparator);
        }

        public bool CheckCondition()
        {
            return _comparator.compare(_id, _value);
        }
    }
}
