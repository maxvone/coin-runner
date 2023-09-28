using CodeBase.Logic.Spawners;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    /// <summary>
    /// Class for visualization of spawn markers on the scene
    /// </summary>
    [CustomEditor(typeof(PickupableSpawnMarker))]
    public class PickupableSpawnMarkerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(PickupableSpawnMarker spawner, GizmoType gizmo)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(spawner.transform.position, 0.5f);
        }
    }
}