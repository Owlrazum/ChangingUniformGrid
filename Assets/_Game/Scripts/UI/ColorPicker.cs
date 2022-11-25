using Cinemachine;
using MLAPI;
using MLAPI.Connection;
using MLAPI.Messaging;
using System;
using UnityEngine;

public class ColorPicker : MonoBehaviour
{
    [SerializeField]
    private ConnectionSystem cs;
    [SerializeField]
    private NetPlayerCreator creator;
    [SerializeField]
    private NetColorSelect colorSelect;
    [SerializeField]
    private GameObject localPlayerPrefab;

    private bool isColorPicked = false;
    public void SelectColor(int colorIndex)
    {
        if (!cs.IsNetworking || isColorPicked)
        {
            return;
        }
        //creator.NewPlayer((byte)colorIndex);
        if (!colorSelect.TrySelectColor((byte)(colorIndex - 1)))
        {
            Debug.Log("NetColor false");
            return;
        }
        //Debug.Log("NetColor true");
        isColorPicked = true;
    }
}
