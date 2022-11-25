using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

using Unity.Netcode;

public class NetPlayerSelection : NetworkBehaviour
{
    NetworkVariable<float> alpha = new NetworkVariable<float>(0);
    private Image image;
    private TextMeshProUGUI textUI;

    private void Awake()
    {
        alpha.OnValueChanged += ProcessAlphaChange;
        image = GetComponent<Image>();
        textUI = GetComponentInChildren<TextMeshProUGUI>();
/*        if (NetworkManager.IsServer)
        { 
            //GetComponent<NetworkObject>().Spawn();        
        }*/
    }
    private void OnDestroy()
    {
        alpha.OnValueChanged -= ProcessAlphaChange;
    }

    private void ProcessAlphaChange(float previousValue, float newValue)
    {
        Color newC = new Color(1, 1, 1, newValue);
        image.color = newC;
    }

    private void ProcessTextChange(string previousValue, string newValue)
    {
        textUI.text = newValue;
    }
    [ServerRpc(RequireOwnership = false)]
    public void SetAlphaServerRpc(float a)
    {
        alpha.Value = a;
    }
    [ServerRpc(RequireOwnership = false)]
    public void SetTextServerRpc(string s)
    {
    }

    public bool CheckAlpha()
    {
        return alpha.Value == 0;
    }
}
