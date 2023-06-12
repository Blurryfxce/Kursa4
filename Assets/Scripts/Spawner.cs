using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    public float spawnRate = 1f;

    public float minHeight = -2f;

    public float maxHeight = 2f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject trees = Instantiate(prefab, transform.position, Quaternion.identity);
        trees.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
