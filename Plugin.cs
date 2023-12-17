using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using Ro_ta_te.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ro_ta_te
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Ro_ta_teModBase : BaseUnityPlugin
    {
        private const string modGUID = "Piggy.Ro_ta_te";
        private const string modName = "Ro_ta_te";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static Ro_ta_teModBase Instance;

        internal ManualLogSource mls;

        public static float rotationSpeed;
        public static bool rotateCollider;
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            rotationSpeed = Config.Bind<float>("ye", "Roation Speed", 1, "yep").Value;
            rotateCollider = Config.Bind<bool>("ye", "Roation Collider", false, "game destroyed").Value;

            mls.LogInfo("Ro ta te is loaded");

            harmony.PatchAll(typeof(Ro_ta_teModBase));
            harmony.PatchAll(typeof(StartOfRoundPatch));
        }
    }
}
