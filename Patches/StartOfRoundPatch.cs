using BepInEx.Logging;
using DunGen;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

namespace Ro_ta_te.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartOfRoundPatch
    {
        public static Vector3 yeetVector = new Vector3(0, 0, Ro_ta_teModBase.rotationSpeed);
        [HarmonyPostfix]
        [HarmonyPatch("Update")]
        private static void Update_Postfix()
        {
            GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

            foreach (GameObject obj in allObjects)
            {
                if (obj.activeSelf)
                {
                    if (obj.GetComponent<Camera>() != null)
                    {
                        continue;
                    }
                    if (obj.layer == LayerMask.NameToLayer("UI"))
                    {
                        continue;
                    }
                    if (obj.name == "Systems")
                    {
                        obj.transform.rotation = Quaternion.identity;
                        continue;
                    }
                    if (obj.name == "Rendering")
                    {
                        obj.transform.rotation = Quaternion.identity;
                        continue;
                    }
                    if (obj.name == "ScavengerHelmet")
                    {
                        obj.SetActive(false);
                        continue;
                    }
                    if (obj.name == "Plane")
                    {
                        continue;
                    }
                    if (!Ro_ta_teModBase.rotateCollider)
                    {
                        if (obj.GetComponent<MeshCollider>() || obj.GetComponent<BoxCollider>() || obj.GetComponent<CapsuleCollider>() || obj.GetComponent<SphereCollider>())
                        {
                            continue;
                        }
                    }
                    if (obj.GetComponent<PlayerControllerB>() != null)
                    {
                        continue;
                    }
                    if (obj.GetComponentInChildren<PlayerControllerB>() != null)
                    {
                        continue;
                    }
                    obj.transform.Rotate(yeetVector * Time.deltaTime);
                }
            }
        }
    }
}
