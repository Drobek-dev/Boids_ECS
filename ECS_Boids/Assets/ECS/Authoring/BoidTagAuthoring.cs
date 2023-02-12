using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class BoidTagAuthoring : MonoBehaviour
{
  
}

public class BoidTagBaker : Baker<BoidTagAuthoring>
{
    public override void Bake(BoidTagAuthoring authoring)
    {
        AddComponent(new BoidTagComponent());
    }
}
