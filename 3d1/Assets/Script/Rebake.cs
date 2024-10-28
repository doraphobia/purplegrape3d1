using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class AutoRebakeNavMesh : MonoBehaviour
{
    public NavMeshSurface navMeshSurface;

    void Update()
    {
        navMeshSurface.BuildNavMesh();
        Debug.Log("NavMesh has been rebuilt!");
    }
}
