using Unity.Entities;
using Unity.Mathematics;

public struct GridSetup : IComponentData
{
    public int2 dims;
    public Entity prefab;
}