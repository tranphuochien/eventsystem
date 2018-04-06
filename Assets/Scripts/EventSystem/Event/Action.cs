using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Script.EventSystem.Global;
using UnityEngine;

namespace Assets.Event
{
    [Serializable]
    public class Action
    {
        public ParamsRaw _params;
        public GameObject _target;
        public ActionType _action;
        public string _name;
        public int _return_code;

        public Action(ActionRaw actionRaw)
        {
            this._params = actionRaw.parameters;
            this._target = Global.GetItem(_params.target);
            this._name = actionRaw.name;
            this._return_code = actionRaw.return_code;
            this._action = ActionsManager.GetActionType(actionRaw.name);
        }

        public int DoAction()
        {
            _action.DoAction(this._target, this._params);
            return this._return_code;
        }
    }

    public abstract class ActionType
    {
        public abstract void DoAction(GameObject gameObject, ParamsRaw paramsRaw = null);
    }

    public class ShowObject : ActionType
    {
        public override void DoAction(GameObject gameObject, ParamsRaw paramsRaw = null)
        {
            gameObject.SetActive(true);
        }
    } 

    public class RotateObject : ActionType
    {
        public override void DoAction(GameObject gameObject, ParamsRaw paramsRaw = null)
        {
             gameObject.transform.Rotate(0, 30* Time.deltaTime, 0, Space.World);
        }
    }

    public class HideObject : ActionType
    {
        public override void DoAction(GameObject gameObject, ParamsRaw paramsRaw = null)
        {
            gameObject.SetActive(false);
        }
    }

    public class ShowPanel : ActionType
    {
        public override void DoAction(GameObject gameObject, ParamsRaw paramsRaw = null)
        {
            //Clone
            UnityEngine.Object.Destroy(GameObject.Find("globalInstance"));
            int curId = Global.getFlag("globalInstance");
            String name = Global.m_instanceMap[curId];
            
            gameObject = UnityEngine.Object.Instantiate(Global.GetItem(name));
            gameObject.transform.parent = GameObject.Find("Main Camera").transform.GetChild(0);
            gameObject.transform.localPosition = new Vector3(-1.7f, 3.1f, 2.7f);
            gameObject.name = "globalInstance";
            gameObject.SetActive(true);
 
        }
    }

    public static class ActionsManager
    {
        private static Dictionary<string, ActionType> _actions = new Dictionary<string, ActionType>();
        private static bool isInit = false;

        private static void Init()
        {
            if (isInit)
                return;
            _actions.Add(Constant.ACTION_SHOW_OBJECT, new ShowObject());
            _actions.Add(Constant.ACTION_HIDE_OBJECT, new HideObject());
            _actions.Add(Constant.ACTION_ROTATE_OBJECT, new RotateObject());
            _actions.Add(Constant.ACTION_SHOW_PANEL, new ShowPanel());
            isInit = true;
        }

        public static ActionType GetActionType(string name)
        {
            Init();
            Debug.Log(name);
            return _actions[name.ToLower()];
        }
    }
}
