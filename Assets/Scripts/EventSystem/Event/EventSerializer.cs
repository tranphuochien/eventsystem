using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assets.Event
{
    [Serializable]
    public class EventSerializer
    {
        public EventRaw[] events;
    }

    [Serializable]
    public class EventRaw
    {
        public string name;
        public PreConditionsRaw[] pre_conditions;
        public ActionRaw action;
        public PostActionRaw[] post_actions;
    }

    [Serializable]
    public class PreConditionsRaw
    {
        public PreConditionRaw[] pre_condition;
    }

    [Serializable]
    public class PreConditionRaw
    {
        public string flagId;
        public int value;
        public string comparator;
    }

    [Serializable]
    public class ActionRaw
    {
        public string name;
        public ParamsRaw parameters;
        public int return_code;
    }

    [Serializable]
    public class ParamsRaw
    {
        public float scale;
        public string target;
        public string type;
        public string action;
    }


    [Serializable]
    public class PostActionRaw
    {
        public int return_code;
        public string flagId;
        public int value;
        public string operator_type;
    }
}
