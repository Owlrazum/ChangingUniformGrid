using UnityEngine;

using Unity.Entities;
using Unity.Entities.Serialization;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Transforms;

public class GridAuthoring : MonoBehaviour
{
    public int2 Dims;
    public GameObject Prefab;
}

class GridBaker : Baker<GridAuthoring>
{
    public override void Bake(GridAuthoring a)
    {
        DependsOn(a.Prefab);
        var p = GetEntity(a.Prefab, TransformUsageFlags.None);
        var e = GetEntity(TransformUsageFlags.None);
        AddComponent(e, new GridSetup() { dims = a.Dims, prefab = p});
    }
}