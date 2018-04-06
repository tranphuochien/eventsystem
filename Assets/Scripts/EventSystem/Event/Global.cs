using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using UnityEngine;

namespace Assets
{
    public static class Global
    {
        public static Dictionary<string, int> _flag = new Dictionary<string, int>();
        public static Dictionary<string, GameObject> _items = new Dictionary<string, GameObject>();
        public static Dictionary<int, String> m_instanceMap = new Dictionary<int, String>();

        public static int getFlag(string key)
        {
            if (!_flag.ContainsKey(key))
            {
                _flag.Add(key, 0);
            }
            return _flag[key];
        }

        public static int setFlag(string key, int value)
        {
            if (_flag.ContainsKey(key))
                _flag.Remove(key);
            _flag.Add(key, value);
            return value;
        }

        public static string RegisterItem(string id, GameObject item)
        {
            m_instanceMap.Add(item.GetInstanceID(), id);
            _items.Add(id, item);
            return id;
        }

        public static GameObject GetItem(string id)
        {
            if (!_items.ContainsKey(id))
                return null;
            return _items[id];
        }

        public static List<Flag> ToList()
        {
            List<Flag> Flags = new List<Flag>();
            foreach (string id in _flag.Keys)
            {
                Flags.Add(new Flag(id, _flag[id]));
            }
            return Flags;
        }

    }

    [Serializable]
    //For debugging in inspector
    public class Flag
    {
        public string _human_readable;
        public string id;
        public int value;

        public Flag(string id, int value)
        {
            this.id = id;
            this.value = value;
            _human_readable = id + ": " + value;
        }
    }
}
