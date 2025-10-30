using UnityEngine;

// Toplanabilir kapsulleri ground ustunde rastgele olusturacak script

public class PickupManager : MonoBehaviour
{
    public GameObject pickupPrefab;
    public GameObject ground;
    public int amount;

    private void Start()
    {
        float groundSizeX = gameObject.transform.localScale.x * 150f;
        float groundSizeZ = gameObject.transform.localScale.z * 150f;

        for(int i = 0; i < amount; i++)
        {
            float randomX = Random.Range(-groundSizeX / 2f, groundSizeX / 2f);
            float randomZ = Random.Range(-groundSizeZ / 2f, groundSizeZ / 2f);

            Vector3 location = new Vector3(randomX, 3f, randomZ);
            Instantiate(pickupPrefab, location, Quaternion.identity);
        }
    }
}
