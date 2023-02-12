using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public partial class BoidSpawnerSystemBase : SystemBase
{
    // Start is called before the first frame update
    protected override void OnUpdate()
    {
        
        EntityQuery boidEntityQuery = EntityManager.CreateEntityQuery(typeof(BoidTagComponent));

        BoidSpawnerComponent bSC = SystemAPI.GetSingleton<BoidSpawnerComponent>();
        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();

        EntityCommandBuffer entityCommandBuffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);
        if (boidEntityQuery.CalculateEntityCount() < 10000)
        {
            Entity spawnedEntity = entityCommandBuffer.Instantiate(bSC.Prefab);
            entityCommandBuffer.SetComponent(
                spawnedEntity,
                new SpeedComponent { 
                    value = randomComponent.ValueRW.random.NextFloat(1f, 5f) 
                    }
                );
        }
    }
}
