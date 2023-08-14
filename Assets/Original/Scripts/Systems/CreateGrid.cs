using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

partial struct CreateGridSystem : ISystem
{
    bool hasRun;

    public void OnUpdate(ref SystemState state)
    {
        if (hasRun)
        {
            return;
        }

        var ecb = new EntityCommandBuffer(Allocator.Temp);

        foreach (var grid in
                 SystemAPI.Query<RefRO<GridSetup>>())
        {
            NativeArray<float3> buffer = new(grid.ValueRO.dims.x * grid.ValueRO.dims.y, Allocator.Temp);
            QuadGridJob job = new() { buffer = buffer, dims = grid.ValueRO.dims, quadSize = 100 };
            job.Execute();
            for (int i = 0; i < buffer.Length; i++)
            {
                UnityEngine.Debug.Log(buffer[i]);
                var e = ecb.Instantiate(grid.ValueRO.prefab);
                ecb.SetComponent<LocalTransform>(e, new LocalTransform() 
                { Position = buffer[i], Rotation = quaternion.identity, Scale = 1 });
            }
        }

        ecb.Playback(state.EntityManager);
        ecb.Dispose();

        hasRun = true;
    }
}