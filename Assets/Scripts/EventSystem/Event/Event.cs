using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Event
{
    [Serializable]
    public class Event
    {
        public string _name;
        public List<PreConditions> _conditions = new List<PreConditions>();
        public List<PostAction> _postActions = new List<PostAction>();
        public Action _action;
        public bool _isTrigged = false;

        public Event(EventRaw eventRaw)
        {
            _name = eventRaw.name;
            _action = new Action(eventRaw.action);
            foreach (PreConditionsRaw preConditionsRaw in eventRaw.pre_conditions)
            {
                _conditions.Add(new PreConditions(preConditionsRaw));
            }
            foreach (PostActionRaw postActionRaw in eventRaw.post_actions)
            {
                _postActions.Add(new PostAction(postActionRaw));
            }
        }
        
        public bool CheckPreCondition()
        {
            //if (_isTrigged)
            //    return false;
            foreach (PreConditions preConditions in _conditions)
            {
                if (preConditions.CheckConditions())
                {
                    Debug.Log(_name + " trigged!");
                    //_isTrigged = true;
                    this._action.DoAction();
                    DoPostActions();
                    return true;
                }
            }
            return false;
        }

        private void DoPostActions()
        {
            foreach (PostAction postAction in _postActions)
            {
                postAction.UpdateFlag();
            }
        }
    }
}
