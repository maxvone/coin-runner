using UnityEngine;

namespace CodeBase.Services.Input
{
    public class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public Vector2 Axis => SimpleInputAxis();

        protected static Vector2 SimpleInputAxis() =>
            new Vector2(SimpleInput.GetAxisRaw(Horizontal), SimpleInput.GetAxisRaw(Vertical));
    }
}