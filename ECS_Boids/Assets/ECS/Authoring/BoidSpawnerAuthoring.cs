using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BoidSpawnerAuthoring : MonoBehaviour
{
    public GameObject prefab;
    
}

public class BoidSpawnerBaker : Baker<BoidSpawnerAuthoring>
{
    public override void Bake(BoidSpawnerAuthoring authoring)
    {
        AddComponent(new BoidSpawnerComponent
        {
            Prefab = GetEntity(authoring.prefab),
        });
    }
}
