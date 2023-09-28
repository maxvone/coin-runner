using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Player
{
    /// <summary>
    /// This class represents the component of movement for the player
    /// It uses InputService to get the input from the player and translates it into movement
    /// </summary>
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [field: SerializeField] public float MovementSpeed { get; set; }

        private IInputService _inputService;
        private Camera _camera;

        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        private void Start() =>
            _camera = Camera.main;

        private void Update() => 
            Move();

        private void Move()
        {
            Vector3 movementVector = Vector3.zero;

            if (_inputService.Axis.sqrMagnitude > Mathf.Epsilon)
            {
                movementVector = _camera.transform.TransformDirection(_inputService.Axis);
                movementVector.y = 0;
                movementVector.z = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;

            _characterController.Move(MovementSpeed * movementVector * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }
}