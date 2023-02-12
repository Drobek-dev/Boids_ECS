using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

using Random = Unity.Mathematics.Random;


public readonly partial struct MoveToPositionAspect : IAspect
{
    private readonly Entity entity; // can only have one, filled with entity thats using this aspect

    private readonly TransformAspect transformAspect;
    private readonly RefRO<SpeedComponent> c_speed;
    private readonly RefRW<TargetPositionComponent> c_targetPosition;

    public void Move(float deltaTime)
    {
        float3 dir = math.normalize(c_targetPosition.ValueRW.value - transformAspect.WorldPosition);
        transformAspect.WorldPosition += deltaTime * c_speed.ValueRO.value * dir;
    }


    public void TestReachedTargetPosition(RefRW<RandomComponent> random)
    {
        float targetDistanceBreakPoint = 0.5f;
        if (math.distance(transformAspect.WorldPosition, c_targetPosition.ValueRW.value) < targetDistanceBreakPoint)
        {
            c_targetPosition.ValueRW.value = GetRandomPosition(random);
        }
    }
    
    private float3 GetRandomPosition(RefRW<RandomComponent> random)
    {
        
        return new float3(
            random.ValueRW.random.NextFloat(0f,10f),
            random.ValueRW.random.NextFloat(0f, 5f),
            random.ValueRW.random.NextFloat(0f, 10f)
            );
    }
}
