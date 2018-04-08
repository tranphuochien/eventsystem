using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constant
{
    public static readonly string ACTION_SHOW_OBJECT = "show-object";
    public static readonly string ACTION_HIDE_OBJECT = "hide-object";
    public static readonly string ACTION_ROTATE_OBJECT = "rotate-object";
    public static readonly string ACTION_SHOW_PANEL = "show-panel";
    public static readonly string ACTION_HIDE_PANEL = "hide-panel";
    public static readonly string ACTION_CHANGE_OBJECT_DETAIL = "change-object";

    public static readonly string COMPARATOR_EQUAL = "equal";
    public static readonly string COMPARATOR_GREATER_THAN = "greater_than";
    public static readonly string COMPARATOR_LESS_THAN = "less_than";
    public static readonly string COMPARATOR_GREATER_THAN_OR_EQUAL = "greater_than_or_equal";
    public static readonly string COMPARATOR_LESS_THAN_OR_EQUAL = "less_than_or_equal";

    public static readonly string OPERATOR_ADD = "add";
    public static readonly string OPERATOR_MINUS = "minus";
    public static readonly string OPERATOR_MULTIPLY = "multiply";
    public static readonly string OPERATOR_DIV = "div";
    public static readonly string OPERATOR_MOD = "mod";
    public static readonly string OPERATOR_SET = "set";


    /*EVENT ID*/
    public const int EVENT_CLICK = 1001;
    public const int EVENT_TOUCH = 1002;

    public static readonly string TARGET_NAME_LABEL = "name_target";
    public static readonly string TARGET_GROUP_LABEL = "group_target";
}
