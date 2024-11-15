using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void Spawn(GameObject objectToSpawn)
    {
        Instantiate(objectToSpawn);
    }

    public void Spawn(GameObject objectToSpawn, Vector3 position)
    {
        Instantiate(objectToSpawn, position, Quaternion.identity);
    }

    public void Spawn(GameObject objectToSpawn, Vector3 position, Transform parentObject)
    {
        Instantiate(objectToSpawn, position, Quaternion.identity, parentObject);
    }
}
