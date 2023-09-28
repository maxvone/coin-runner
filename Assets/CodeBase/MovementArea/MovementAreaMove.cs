using UnityEngine;

namespace CodeBase.MovementArea
{
    /// <summary>
    /// The class is responsible for controlling movement of the MovementArea
    /// </summary>
    public class MovementAreaMove : MonoBehaviour
    {
        public float Speed { get; set; }

        private void Update() => 
            transform.position += -transform.forward * Speed * Time.deltaTime;

    }
}
