using JetBrains.Annotations;
using UnityEngine.AI;

namespace Core.Environment
{
    public interface IProvideNavMeshSurface
    {
        public bool RuntimeBuild { get; }
        [CanBeNull] public NavMeshSurface NavMeshSurface { get; }

        void BuildAtRuntime(bool option);
        public void BuildNavMesh();
    }
}