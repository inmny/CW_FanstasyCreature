// 这个文件是一个隐藏的文件, 用来给IDE识别`Mod`这个内部全局变量using System;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace CW_FantasyCreatures;

internal class Mod
{
    public static ModDeclaration.Info Info;
    public static GameObject GameObject;
    public static Action OnDebug;

    public static void Initialize(Button button)
    {
    }

    public class EmbededResources
    {
        public static Sprite LoadSprite(string name, float pivotX = 0, float pivotY = 0, float pixelsPerUnit = 1f)
        {
            throw new NotImplementedException();
        }

        public static byte[] GetBytes(string name)
        {
            throw new NotImplementedException();
        }
    }
}