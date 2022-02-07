using Core.Environment;
using UnityEngine;
using UnityEngine.AI;

namespace MonoBehaviors.Environment
{
    public class NavMeshSurfaceProvider : MonoBehaviour, IProvideNavMeshSurface
    {
        // Inspector GUI
        public NavMeshSurface navMeshSurface;
        public bool buildAtRuntime;

        private void Start()
        {
            navMeshSurface ??= GetComponent<NavMeshSurface>();
            RuntimeBuild = buildAtRuntime; // tie in inspector value with interface value

            BuildNavMesh();
        }

        public bool RuntimeBuild { get; private set; }

        public NavMeshSurface NavMeshSurface => navMeshSurface;

        [ContextMenu("Build Nav Mesh")]
        public void BuildNavMesh()
        {
            if (RuntimeBuild) navMeshSurface.BuildNavMesh();
        }

        public void BuildAtRuntime(bool option)
        {
            buildAtRuntime = option;
        }
    }
}