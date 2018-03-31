using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Event
{
    [Serializable]
    public class PostAction
    {
        public string _human_readable;
        public string _id;
        public int _value;
        public string _type;

        public Operator _oper;

        public PostAction(PostActionRaw postActionRaw)
        {
            this._id = postActionRaw.flagId;
            this._value = postActionRaw.value;
            this._type = postActionRaw.operator_type;
            _oper = OperatorsManager.GetOperator(postActionRaw.operator_type);
            _human_readable = _type + " " + _id + " with " + _value;
        }

        public int UpdateFlag()
        {
            return _oper.Operate(_id, _value);
        }
    }
}
