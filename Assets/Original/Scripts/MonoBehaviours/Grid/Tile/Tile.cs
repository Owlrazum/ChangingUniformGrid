using UnityEngine;
using UnityEngine.Assertions;

public class Tile : MonoBehaviour
{
    private MeshRenderer _renderer;
    private void Awake()
    {
        bool isFound = TryGetComponent(out _renderer);
        Assert.IsTrue(isFound);
    }

    public void ChangeMaterial(Material material)
    {
        _renderer.sharedMaterial = material;
    }
}

