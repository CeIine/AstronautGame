using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAutoBuilder : MonoBehaviour
{
    protected void Awake()
    {
        var markups = new List<NavMeshBuildMarkup>();
        var sources = new List<NavMeshBuildSource>();

        NavMeshBuilder.CollectSources(transform,
            LayerMask.GetMask("Default"),
            NavMeshCollectGeometry.PhysicsColliders,
            NavMesh.GetAreaFromName("Walkable"),
            markups,
            sources);
        
        var settings = NavMesh.GetSettingsByIndex(0);
        var data = NavMeshBuilder.BuildNavMeshData(
            settings,
            sources,
            new Bounds(
                Vector3.zero,
                new Vector3(50f, 0.5f, 50f)),
            Vector3.zero,
            Quaternion.identity);

        NavMesh.AddNavMeshData(data);
    }
}
