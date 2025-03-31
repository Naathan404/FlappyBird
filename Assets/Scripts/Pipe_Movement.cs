using UnityEngine;

public class Pipe_Movement : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 1.8f;
    void Update()
    {
        this.transform.position += Vector3.left * rollSpeed * Time.deltaTime;
    }
}
