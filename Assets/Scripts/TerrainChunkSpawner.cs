using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TerrainChunkSpawner : MonoBehaviour

{
    [Header("Terrain")]
    [SerializeField] private Transform player;
    [SerializeField] private GameObject groundPrefab;
    [SerializeField] private float chunkWidth = 112f;
    [SerializeField] private float spawnAhead = 200f;
    [SerializeField] private float overlap = 15f;

    [Header("FUEL")]
    [SerializeField] private GameObject fuelPrefab;  // Your Fuel prefab
    [SerializeField] private float fuelSpacing = 100f;  // Every 100 meters
    [SerializeField] private float fuelHeightOffset = 1.5f;  // Above terrain

    private Queue<GameObject> chunkPool = new Queue<GameObject>();
    private float nextChunkX = 0f;
    private float nextFuelX = 50f;  // First fuel at 50m

    void Start()
    {
        // Create terrain chunks
        for (int i = 0; i < 6; i++)
        {
            GameObject chunk = Instantiate(groundPrefab, transform);
            chunk.SetActive(false);
            chunkPool.Enqueue(chunk);
        }
        for (int i = 0; i < 3; i++) SpawnChunk();

        // First fuel spawns ahead
        SpawnFuelIfNeeded();
    }

    void Update()
    {
        if (player == null) return;

        // Spawn terrain chunks
        while (nextChunkX < player.position.x + spawnAhead)
        {
            SpawnChunk();
        }

        // Spawn fuel every 100m
        SpawnFuelIfNeeded();

        // Recycle old chunks
        RecycleOldChunks();
    }

    void SpawnFuelIfNeeded()
    {
        while (nextFuelX < player.position.x + spawnAhead)
        {
            if (fuelPrefab != null)
            {
                Vector3 fuelPos = new Vector3(nextFuelX, fuelHeightOffset, 0);
                Instantiate(fuelPrefab, fuelPos, Quaternion.identity, transform);
                Debug.Log($"Fuel spawned at X: {nextFuelX}");
            }
            nextFuelX += fuelSpacing;  // Next fuel 100m ahead
        }
    }

    void SpawnChunk()
    {
        if (chunkPool.Count == 0) return;

        GameObject chunk = chunkPool.Dequeue();
        chunk.transform.position = new Vector3(nextChunkX, 0, 0);
        chunk.GetComponent<TerrainChunk>().Generate(nextChunkX);
        chunk.SetActive(true);

        nextChunkX += chunkWidth - overlap;
        chunkPool.Enqueue(chunk);
    }

    void RecycleOldChunks()
    {
        foreach (GameObject chunk in chunkPool)
        {
            if (chunk.activeInHierarchy &&
                chunk.transform.position.x + chunkWidth < player.position.x - spawnAhead)
            {
                chunk.SetActive(false);
            }
        }
    }
}
