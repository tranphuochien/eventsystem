using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Script.EventSystem.Global
{
    public static class ObjectDictionary
    {
        private static Dictionary<string, GameObject> _gameObjects;

        public static void Register(string name, GameObject gameObject)
        {
            _gameObjects.Add(name, gameObject);
        }

        public static GameObject GetObject(string name)
        {
            if (_gameObjects.ContainsKey(name))
            {
                return _gameObjects[name];
            }
            return null;
        }
    }
}
