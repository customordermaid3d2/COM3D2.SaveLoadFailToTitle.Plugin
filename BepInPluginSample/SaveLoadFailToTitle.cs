using BepInEx;
using BepInEx.Configuration;
using COM3D2API;
using HarmonyLib;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace COM3D2.SaveLoadFailToTitle.Plugin
{
    [BepInPlugin(MyAttribute.PLAGIN_FULL_NAME, MyAttribute.PLAGIN_FULL_NAME, MyAttribute.PLAGIN_VERSION)]// 버전 규칙 잇음. 반드시 2~4개의 숫자구성으로 해야함. 미준수시 못읽어들임
    public class SaveLoadFailToTitle : BaseUnityPlugin
    {

        Harmony harmony;

        public void OnEnable()
        {
            harmony = Harmony.CreateAndPatchAll(typeof(SaveLoadFailToTitlePatch));
        }
        public void OnDisable()
        {
            harmony.UnpatchSelf();
        }

    }
}
