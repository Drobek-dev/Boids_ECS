using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

[BurstCompile]
public partial struct MovingSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        
    }

    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {
       
    }

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        JobHandle jobhandle = new MoveJob { deltaTime = deltaTime}.ScheduleParallel(state.Dependency);

        jobhandle.Complete();


        RefRW<RandomComponent> randomComponent = SystemAPI.GetSingletonRW<RandomComponent>();
        new TestReachedPositionJob { randomComponent = randomComponent}.Run();
    }
}

[BurstCompile]
public partial struct MoveJob: IJobEntity
{
    public float deltaTime;
    [BurstCompile]
    public void Execute(MoveToPositionAspect mTPA)
    {
        mTPA.Move(deltaTime);
    }
}

[BurstCompile]
public partial struct TestReachedPositionJob : IJobEntity
{
    [NativeDisableUnsafePtrRestriction] public RefRW<RandomComponent> randomComponent;
    [BurstCompile]
    public void Execute(MoveToPositionAspect mTPA)
    {
        mTPA.TestReachedTargetPosition(randomComponent);
    }
}

