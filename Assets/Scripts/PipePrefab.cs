using UnityEngine;

public class PipePrefab : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;

    private void Update()
    {
        PipeMovement();
        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }

    }
    private void PipeMovement()
    {
        transform.position += -transform.right * speedMultiplier * Time.deltaTime;
    }
}
