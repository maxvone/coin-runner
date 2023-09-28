using System.Linq;
using CodeBase.Logic.Spawners;
using CodeBase.StaticData.Levels;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Editor
{
    /// <summary>
    /// This class is responsible for collecting static data from the scene such as:
    /// - Markers for spawning pickupables
    /// This static data is used in LoadLevelState to spawn pickupables
    /// </summary>
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelData = (LevelStaticData)target;

            if (GUILayout.Button("Collect"))
            {
                levelData.PickupablesSpawners = FindObjectsOfType<PickupableSpawnMarker>()
                    .Select(x => new PickupableSpawnerStaticData(x.TypeId, x.transform.position, x.Prefab))
                    .ToList();
                levelData.LevelKey = SceneManager.GetActiveScene().name;
            }

            EditorUtility.SetDirty(target);
        }
    }
}