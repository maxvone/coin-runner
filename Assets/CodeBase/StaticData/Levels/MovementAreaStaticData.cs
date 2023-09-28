using UnityEngine;

namespace CodeBase.StaticData.Levels
{
    [CreateAssetMenu(fileName = "MovementAreaData", menuName = "Static Data/MovementArea")]
    public class MovementAreaStaticData : ScriptableObject
    {
        public float Speed;
    }
}