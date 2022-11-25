using System.Collections.Generic;
using UnityEngine;

public class NetGrid : MonoBehaviour
{
    public static NetGrid Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        tiles = GridGenerator.Instance.GenerateTiles();
        NetEventSystem.Instance.TilesInitialized();
    }
    public List<List<NetTile>> tiles;
}
