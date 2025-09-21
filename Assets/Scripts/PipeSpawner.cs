using System.Runtime.CompilerServices;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;

    private float timeInterval=0f ;
    private float maxTimeInterval = 0.9f;
    private float heightOffset = 2f;

    private void Start()
    {
        CreatePipePrefab();
    }
    private void Update()
    {
        
        CreatePipePrefab();
       
    }

    private void CreatePipePrefab()
    {
        if (timeInterval >= maxTimeInterval)
        {
            Instantiate(pipePrefab, new Vector3(transform.position.x,Random.Range(-heightOffset,heightOffset),0), Quaternion.identity);
            timeInterval = 0f;
        }
        else
        {
            timeInterval += Time.deltaTime;
        }
        
    }
}
