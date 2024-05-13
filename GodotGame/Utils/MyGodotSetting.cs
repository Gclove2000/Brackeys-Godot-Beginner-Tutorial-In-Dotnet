using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodotGame.Utils
{
    public static class MyGodotSetting
    {

        /// <summary>
        /// 重力
        /// </summary>
        public const double GRAVITY = 980;

        public enum InputMapEnum { Left, Right, Up, Down, Jump };

        public static bool IsActionJustPressed(InputMapEnum inputMapEnum)
        {
            return Input.IsActionJustPressed(inputMapEnum.ToString());
        }

        public static bool IsActionJustReleased(InputMapEnum inputMapEnum)
        {
            return Input.IsActionJustReleased(inputMapEnum.ToString());
        }

        public static bool IsActionPressed(InputMapEnum inputMapEnum)
        {
            return Input.IsActionPressed(inputMapEnum.ToString());
        }
    }
}
