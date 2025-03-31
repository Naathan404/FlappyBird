using Unity.VisualScripting;
using UnityEngine;

public class Spawning_Pipe : MonoBehaviour
{
    [SerializeField] private float cooldown = 2.0f;
    [SerializeField] private float deltaDistance;
    public GameObject Pipe;
    private float time = 0.0f;
    void Start()
    {
        GeneratePipe();
    }

    void Update()
    {
        if(time > cooldown)
        { 
            time = 0.0f;
            GeneratePipe();
        }
        time += Time.deltaTime;
    }

    private void GeneratePipe()
    {
        Vector3 genPosition = transform.position + new Vector3(0, Random.Range(-deltaDistance, deltaDistance));
        GameObject genPipe = Instantiate(Pipe, genPosition, Quaternion.identity);
        // Xoa bo Pipe
        Destroy(genPipe, 4.0f);
    }
}
