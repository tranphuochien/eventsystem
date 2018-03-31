using System;
using Boo.Lang;
using UnityEngine;

namespace Assets.Event
{
    [Serializable]
    public class PreConditions
    {
        public List<Condition> _conditions = new List<Condition>();

        public PreConditions(PreConditionsRaw preConditionsRaw)
        {
            foreach (PreConditionRaw conditionRaw in preConditionsRaw.pre_condition)
            {
                _conditions.Add(new Condition(conditionRaw));
            }
        }

        public bool CheckConditions()
        {
            foreach (Condition condition in _conditions)
            {
                if (!condition.CheckCondition())
                    return false;
            }
            return true;
        }
    }
}