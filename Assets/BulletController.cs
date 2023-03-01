using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float lifetime = 2f;



    // public float speed = 10f;
    public int damage = 1;

    private GameObject owner;



    private void Start()
    {
        // Destroy the bullet after its lifetime has elapsed
        Destroy(gameObject, lifetime);
    }


    public void SetOwner(GameObject newOwner)
    {
        owner = newOwner;
    }



    private void OnTriggerEnter2D(Collider2D other)
    {

        // Check if the bullet hit an enemy
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null && other.gameObject != owner)
        {
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
