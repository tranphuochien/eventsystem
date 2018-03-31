using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Event
{
    public abstract class Operator
    {
        public abstract int Operate(string FlagId, int value);
    }

    public class Add : Operator
    {
        public override int Operate(string FlagId, int value)
        {
            return Global.setFlag(FlagId, Global.getFlag(FlagId) + value);
        }
    }

    public class Minus : Operator
    {
        public override int Operate(string FlagId, int value)
        {
            return Global.setFlag(FlagId, Global.getFlag(FlagId) - value);
        }
    }


    public class Multiply : Operator
    {
        public override int Operate(string FlagId, int value)
        {
            return Global.setFlag(FlagId, Global.getFlag(FlagId) * value);
        }
    }

    public class Div : Operator
    {
        public override int Operate(string FlagId, int value)
        {
            return Global.setFlag(FlagId, Global.getFlag(FlagId) / value);
        }
    }
    
    public class Mod : Operator
    {
        public override int Operate(string FlagId, int value)
        {
            return Global.setFlag(FlagId, Global.getFlag(FlagId) % value);
        }
    }

    public class Set : Operator
    {
        public override int Operate(string FlagId, int value)
        {
            return Global.setFlag(FlagId, value);
        }
    }

    public static class OperatorsManager
    {
        private static Dictionary<string, Operator> Operators = new Dictionary<string, Operator>();
        private static bool isInit = false;

        private static void Init()
        {
            if (isInit == true)
                return;
            Operators.Add(Constant.OPERATOR_ADD, new Add());
            Operators.Add(Constant.OPERATOR_MINUS, new Minus());
            Operators.Add(Constant.OPERATOR_MULTIPLY, new Multiply());
            Operators.Add(Constant.OPERATOR_DIV, new Div());
            Operators.Add(Constant.OPERATOR_MOD, new Mod());
            Operators.Add(Constant.OPERATOR_SET, new Set());
            isInit = true;
        }

        public static Operator GetOperator(string name)
        {
            Init();
            return Operators[name.ToLower()];
        }
    }

}
