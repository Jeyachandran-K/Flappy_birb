using System.Runtime.CompilerServices;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;

   

    private float timeInterval=0f ;
    private float maxTimeInterval = 0.9f;
    private float heightOffset = 2.5f;
    private bool gameHasStarted;

    private void Start()
    {
        Birb.Instance.OnGamingState += Birb_OnGamingState;
        if (gameHasStarted)
        {
            CreatePipePrefab();
        }
    }

    private void Birb_OnGamingState()
    {
        gameHasStarted = true;
    }

    private void Update()
    {
        if (gameHasStarted) {
            CreatePipePrefab();
        }
    }

    private void CreatePipePrefab()
    {

        
            if (timeInterval >= maxTimeInterval)
            {
                Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(-heightOffset, heightOffset), 0), Quaternion.identity);
                timeInterval = 0f;
            }
            else
            {
                timeInterval += Time.deltaTime;
            }
        
        
    }
}
