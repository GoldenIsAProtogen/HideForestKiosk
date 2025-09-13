using System.Collections.Generic;
using BepInEx;
using UnityEngine;

namespace HideForestKiosk
{
    [BepInPlugin(Constants.GUID, Constants.Name, Constants.Version)]
    public class HideForestKiosk : BaseUnityPlugin
    {
        private List<GameObject> ds = new List<GameObject>();
        void Start() => GorillaTagger.OnPlayerSpawned(GS);

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
                FK.FindChildRecursive("rig").gameObject
            };
            foreach (var g in ds)
            {
                g.SetActive(false);
            }
            Destroy(CM(170244));
            Destroy(CM(170176));
        }
    }
}



