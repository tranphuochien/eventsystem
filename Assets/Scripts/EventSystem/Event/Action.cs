﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Script.EventSystem.Global;
using UnityEngine;
using UnityEngine.Rendering;

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
             gameObject.transform.Rotate(0, 0, 30 * Time.deltaTime, Space.World);
        }
    }

    public class HideObject : ActionType
    {
        public override void DoAction(GameObject gameObject, ParamsRaw paramsRaw = null)
        {
            gameObject.SetActive(false);
        }
    }

    public class ChangeObjectDetail : ActionType
    {
        public override void DoAction(GameObject gameObject, ParamsRaw paramsRaw = null)
        {
            if (Global.curInstanceObject == Global.getFlag("globalInstance"))
            {
                return;
            }

            UnityEngine.Object.Destroy(GameObject.Find("globalInstance"));
            int curId = Global.getFlag("globalInstance");
            Global.curInstanceObject = curId;
            String name = Global.m_instanceMap[curId];
            
            gameObject = UnityEngine.Object.Instantiate(Global.GetItem(name));
            gameObject.transform.parent = GameObject.Find("Main Camera").transform.GetChild(0);
            gameObject.transform.localPosition = new Vector3(-1.86f, 3.1f, 1.94f);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            gameObject.transform.eulerAngles = new Vector3(40, 150, 10);
            gameObject.AddComponent<Rotate> ();
            gameObject.name = "globalInstance";
            gameObject.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
        }
    }

    public class ShowPanel : ActionType
    {
        public override void DoAction(GameObject gameObject, ParamsRaw paramsRaw = null)
        {
            GameObject screen = Global.GetItem("Screen");
            screen.GetComponent<Slide>().SlideIn();
        }
    }

    public class HidePanel : ActionType
    {
        public override void DoAction(GameObject gameObject, ParamsRaw paramsRaw = null)
        {
            GameObject screen = Global.GetItem("Screen");
            screen.GetComponent<Slide>().SlideOut();
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
            _actions.Add(Constant.ACTION_CHANGE_OBJECT_DETAIL, new ChangeObjectDetail());
            _actions.Add(Constant.ACTION_SHOW_PANEL, new ShowPanel());
            _actions.Add(Constant.ACTION_HIDE_PANEL, new HidePanel());
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
