using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject collectibleBase;
    public BoxCollider2D spawnArea;
    public float minSpeed = 4.0f;
    public float maxSpeed = 8.0f;

    void Start()
    {
        collectibleBase.SetActive(false);
        InvokeRepeating("SpawnObject", 0f, 3f);
    }

    void SpawnObject()
    {
        float minX = spawnArea.bounds.min.x;
        float maxX = spawnArea.bounds.max.x;

        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        Rigidbody rb = collectibleBase.GetComponent<Rigidbody>();
        rb.velocity = new Vector2(0f, -randomSpeed);

        collectibleBase.SetActive(true);
        collectibleBase.transform.position = spawnPosition;
    }
}
