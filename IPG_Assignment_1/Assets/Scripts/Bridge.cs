using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject BridgeObj;

    [Header("Triggers")]
    public LanternLight Lantern1;
    public LanternLight Lantern2;

    // Update is called once per frame
    void Update()
    {
        bool BridgeEnabled = Lantern1.SwitchedOn && Lantern2.SwitchedOn;
        BridgeObj.SetActive(BridgeEnabled);
    }
}
