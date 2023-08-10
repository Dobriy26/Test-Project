using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float spawnRate = 1f;
    [SerializeField]
    private Vector2 spawnAreaSize = new Vector2(50f, 50f); 

    private Camera mainCamera;
    private float nextSpawnTime;

    private void Start()
    {
        mainCamera = Camera.main;
        nextSpawnTime = Time.time + spawnRate;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPosition;

        do
        {
            
            spawnPosition = new Vector2(
                Random.Range(transform.position.x - spawnAreaSize.x / 2f, transform.position.x + spawnAreaSize.x / 2f),
                Random.Range(transform.position.y - spawnAreaSize.y / 2f, transform.position.y + spawnAreaSize.y / 2f)
            );
        }
        
        while (IsInCameraView(spawnPosition));

        
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    private bool IsInCameraView(Vector2 position)
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1;
    }

   
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}