using System.Collections.Generic;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace HideForestKiosk
{
    [BepInPlugin(Constants.GUID, Constants.Name, Constants.Version)]
    public class HideForestKiosk : BaseUnityPlugin
    {
        private List<GameObject> ds = new List<GameObject>();
        private ConfigEntry<bool> creatorboard;
        void Start()
        {
            creatorboard = Config.Bind("CreatorBoard", "Enabled", false, "CreatorBoard Enabled");
            GorillaTagger.OnPlayerSpawned(GS);
        }

        // Thanks to DecalFree <3
        public UnityEngine.Object CM(int iid)
        {
            return (UnityEngine.Object)typeof(UnityEngine.Object)
                .GetMethod("FindObjectFromInstanceID", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                .Invoke(null, new object[] { iid });
        }

        void GS()
        {
            Transform FK = GameObject.Find("LocalObjects_Prefab").transform.FindChildRecursive("ForestKiosk_Anchor");
            ds = new List<GameObject>()
            {
                FK.transform.FindChildRecursive("gorilla_new").GetChild(2).gameObject,
                FK.FindChildRecursive("EndCap_PackSign").gameObject,
                FK.FindChildRecursive("EndCap_BackgroundTexture").gameObject,
                FK.FindChildRecursive("PurchaseButton").gameObject,
                FK.FindChildRecursive("CreatorCodeMonitor").gameObject,
                FK.FindChildRecursive("FrontPanel_Center").gameObject,
                FK.FindChildRecursive("rig").gameObject,
                FK.FindChildRecursive("SteampunkJacket Functional Prefab").gameObject,
                FK.FindChildRecursive("RC_ShipSteamPunk_FBX").gameObject
            };
            foreach (var g in ds)
            {
                g.SetActive(false);
            }
            if (creatorboard.Value)
            {
                Destroy(CM(170526));
                Destroy(CM(171440));
            }
        }
    }
}
