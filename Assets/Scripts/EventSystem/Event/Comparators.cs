using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Assets.Event
{
    [Serializable]
    public abstract class Comparator
    {
        public abstract bool compare(string FlagId, int value);
    }

    public class GreaterThan : Comparator
    {
        public override bool compare(string FlagId, int value)
        {
            return Global.getFlag(FlagId) > value;
        }
    }

    public class LessThan : Comparator
    {
        public override bool compare(string FlagId, int value)
        {
            return Global.getFlag(FlagId) < value;
        }
    }

    public class Equal : Comparator
    {
        public override bool compare(string FlagId, int value)
        {
            return Global.getFlag(FlagId) == value;
        }
    }

    public class GreaterThanOrEqual : Comparator
    {
        public override bool compare(string FlagId, int value)
        {
            return Global.getFlag(FlagId) >= value;
        }
    }

    public class LessThanOrEqual : Comparator
    {
        public override bool compare(string FlagId, int value)
        {
            return Global.getFlag(FlagId) <= value;
        }
    }

    public static class ComparatorsManager
    {
        private static Dictionary<string, Comparator> Operators = new Dictionary<string, Comparator>();

        private static bool isInit = false;

        public static void Init()
        {
            if (isInit == true)
                return;
            Operators.Add(Constant.COMPARATOR_EQUAL, new Equal());
            Operators.Add(Constant.COMPARATOR_GREATER_THAN, new GreaterThan());
            Operators.Add(Constant.COMPARATOR_LESS_THAN, new LessThan());
            Operators.Add(Constant.COMPARATOR_GREATER_THAN_OR_EQUAL, new GreaterThanOrEqual());
            Operators.Add(Constant.COMPARATOR_LESS_THAN_OR_EQUAL, new LessThanOrEqual());
            isInit = true;
        }
        public static Comparator GetComparator(string name)
        {
            Init();
            return Operators[name.ToLower()];
        }
    }
}