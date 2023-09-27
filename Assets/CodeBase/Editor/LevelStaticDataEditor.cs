using System.Linq;
using CodeBase.Logic.Spawners;
using CodeBase.StaticData.Levels;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Editor
{
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
                    .Select(x => new PickupableSpawnerStaticData(x.TypeId, x.transform.position))
                    .ToList();
                levelData.LevelKey = SceneManager.GetActiveScene().name;
            }

            EditorUtility.SetDirty(target);
        }
    }
}