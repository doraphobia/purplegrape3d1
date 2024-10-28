using System;
using UnityEngine;

namespace Unity.AI.Navigation.Samples
{
    public class SpawnPrefabOnKeyDown : MonoBehaviour
    {
        [SerializeField]
        GameObject prefab; // The prefab to spawn

        [SerializeField]
        KeyCode keyCode; // The key to trigger spawning/destroying

        [SerializeField]
        Transform spawnedPrefabsHolder; // Parent object for spawned prefabs

        Transform m_Transform; // Cache for the object's transform
        GameObject spawnedPrefab; // Reference to the spawned object
        bool isSpawned = false; // Tracks if the object is spawned

        void Start()
        {
            m_Transform = transform;

            if (spawnedPrefabsHolder == null)
            {
                spawnedPrefabsHolder = m_Transform; // If no parent is set, use the object's own transform
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(keyCode))
            {
                if (isSpawned)
                {
                    // Destroy the prefab if it's already spawned
                    Destroy(spawnedPrefab);
                    isSpawned = false;
                }
                else
                {
                    // Instantiate the prefab if it's not spawned yet
                    spawnedPrefab = Instantiate(prefab, m_Transform.position, m_Transform.rotation, spawnedPrefabsHolder);
                    isSpawned = true;
                }
            }
        }
    }
}