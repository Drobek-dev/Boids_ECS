using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class TargetPosiotionAuthoring : MonoBehaviour
{
    public float3 value;
}

public class TargetPositionBaker : Baker<TargetPosiotionAuthoring>
{
    public override void Bake(TargetPosiotionAuthoring authoring)
    {
        AddComponent(new TargetPositionComponent { value= authoring.value });
    }
}