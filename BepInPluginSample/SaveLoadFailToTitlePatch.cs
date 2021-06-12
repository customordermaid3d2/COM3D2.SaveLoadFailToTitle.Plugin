using COM3D2.Lilly.Plugin;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BepInPluginSample
{
    class SaveLoadFailToTitlePatch
    {
        [HarmonyPatch(typeof(GameMain), "Deserialize", new Type[] { typeof(int), typeof(bool) })]
        [HarmonyPostfix]
        public static void Deserialize(ref bool __result)
        {
            if (!__result)
            {
                GameMain.Instance.LoadScene("SceneToTitle");
            }
        }
    }
}
