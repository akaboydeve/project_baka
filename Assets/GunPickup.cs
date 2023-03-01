using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public GameObject gunPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Add the gun to the player's inventory
            other.gameObject.GetComponent<PlayerInventory>().AddGun(gunPrefab);

            // Destroy the gun pickup object
            Destroy(gameObject);
        }
    }
}
