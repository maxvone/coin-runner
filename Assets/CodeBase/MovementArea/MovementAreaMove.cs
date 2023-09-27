using UnityEngine;

public class MovementAreaMove : MonoBehaviour
{
    public float Speed { get; set; } = 7;

    private void Update() => 
        transform.position += -transform.forward * Speed * Time.deltaTime;

}
