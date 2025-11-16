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

        void GS()
        {
            Transform FK = GameObject.Find("LocalObjects_Prefab").transform.FindChildRecursive("ForestKiosk_Anchor");
            ds = new List<GameObject>()
            {
                //FK.transform.FindChildRecursive("gorilla_new").GetChild(2).gameObject,
                FK.FindChildRecursive("EndCap_PackSign").gameObject,
                FK.FindChildRecursive("EndCap_BackgroundTexture").gameObject,
                FK.FindChildRecursive("PurchaseButton").gameObject,
                FK.FindChildRecursive("CreatorCodeMonitor").gameObject,
                FK.FindChildRecursive("FrontPanel_Center").gameObject,
                FK.FindChildRecursive("ShirtStormElectric Functional Prefab").gameObject,
                FK.FindChildRecursive("PantsStormElectric Wardrobe Variant").gameObject,
                FK.FindChildRecursive("GlovesStormElectric_Functional_Variant").gameObject
            };
            foreach (var g in ds)
            {
                g.SetActive(false);
            }

            string[] extraObjs =
            {
                "UnityTempFile-4cabead2c1674d749955c629707e1820 (combined by EdMeshCombiner)"
            };

            foreach (string name in extraObjs)
            {
                var obj = GameObject.Find(name);
                if (obj != null)
                    obj.SetActive(false);
            }
        }
    }
}
