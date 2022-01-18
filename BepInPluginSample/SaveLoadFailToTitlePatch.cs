using HarmonyLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace COM3D2.SaveLoadFailToTitle.Plugin
{
	class MyAttribute
	{
		public const string PLAGIN_NAME = "SaveLoadFailToTitle";
		public const string PLAGIN_VERSION = "21.6.13";
		public const string PLAGIN_FULL_NAME = "COM3D2.SaveLoadFailToTitle.Plugin";
	}

	class SaveLoadFailToTitlePatch
    {
        [HarmonyPatch(typeof(GameMain), "Deserialize", new Type[] { typeof(int), typeof(bool) })]
        [HarmonyPostfix]
        public static void Deserialize(GameMain __instance, ref bool __result, int f_nSaveNo, bool scriptExec = true)
        {
            if (!__result)
            {
				//this.CMSystem.m_GenericTmpFlag.Clear();
				//this.m_TutorialPanel.Reset();

				string text = __instance.MakeSavePathFileName(f_nSaveNo);
				NDebug.Assert(File.Exists(text), "ファイルを開けません。" + text);
				FileStream fileStream = new FileStream(text, FileMode.Open);
				if (fileStream == null)
				{
					Debug.LogWarning("GameMain.Deserialize fileStream == null");
					goto End;
				}
				byte[] buffer = new byte[fileStream.Length];
				fileStream.Read(buffer, 0, (int)fileStream.Length);
				fileStream.Close();
				fileStream.Dispose();
				BinaryReader binaryReader = new BinaryReader(new MemoryStream(buffer));

				End:

				Debug.LogError("GameMain.Deserialize Fail");
                GameMain.Instance.LoadScene("SceneToTitle");
            }
        }
    }
}
