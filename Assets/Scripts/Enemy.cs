using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAroundCamera : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnDistance = 5.0f;
    public int maxPrefabs = 8; // Maximum number of prefabs to spawn.

    private int prefabsSpawned = 0;
    private GameObject spawnedPrefab;

    void Start()
    {
        StartCoroutine(SpawnPrefabs());
    }

    IEnumerator SpawnPrefabs()
    {
        if (prefabToSpawn == null)
        {
            Debug.LogError("Prefab to spawn is not set!");
            yield break;
        }

        if (Camera.main == null)
        {
            Debug.LogError("Main camera not found!");
            yield break;
        }

        while (prefabsSpawned < maxPrefabs)
        {
            // Calculate a random angle around the camera.
            float angle = Random.Range(0f, 360f);
            // Convert the angle to radians.
            float angleInRadians = angle * Mathf.Deg2Rad;

            // Calculate the spawn position around the camera based on the angle and distance.
            Vector3 spawnPosition = Camera.main.transform.position +
                new Vector3(Mathf.Cos(angleInRadians), 0, Mathf.Sin(angleInRadians)) * spawnDistance;

            // Instantiate the prefab at the calculated position.
            spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

            // Wait until the prefab is destroyed before spawning the next one.
            yield return new WaitUntil(() => spawnedPrefab == null);

            prefabsSpawned++;
        }
    }

    void Update()
    {
        // Check for the Spacebar input to destroy the spawned prefab.
        if (Input.GetKeyDown(KeyCode.Space) && spawnedPrefab != null)
        {
            Destroy(spawnedPrefab);
        }
    }
}
