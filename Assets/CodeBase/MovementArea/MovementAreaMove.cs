using UnityEngine;

public class MovementAreaMove : MonoBehaviour
{
    public float Speed { get; set; } = 4;

    private void Update() => 
        transform.position += -transform.forward * Speed * Time.deltaTime;

}
