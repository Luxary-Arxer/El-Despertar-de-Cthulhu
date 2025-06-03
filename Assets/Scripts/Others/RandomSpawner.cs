using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public int numberOfObjects = 5;
    public Collider areaCollider;

    public Vector2 scaleRange = new Vector2(0.5f, 2f);
    public float rotationRange = 360f;

    public int seed = 5;

    void Start()
    {
        if (areaCollider == null)
        {
            Debug.LogError("¡El collider no está asignado!");
            return;
        }

        Random.InitState(seed);
        SpawnObjects();
    }

    void SpawnObjects()
    {
        Bounds bounds = areaCollider.bounds;

        for (int i = 0; i < numberOfObjects; i++)
        {
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);
            float z = Random.Range(bounds.min.z, bounds.max.z);
            Vector3 position = new Vector3(x, y, z);

            int randomIndex = Random.Range(0, prefabs.Length);
            GameObject selectedPrefab = prefabs[randomIndex];

            GameObject obj = Instantiate(selectedPrefab, position, Quaternion.identity);

            float scale = Random.Range(scaleRange.x, scaleRange.y);
            obj.transform.localScale = new Vector3(scale, scale, scale);

            float rotationY = Random.Range(0f, rotationRange);
            obj.transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        }
    }
}
