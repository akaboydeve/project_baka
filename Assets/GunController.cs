using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 50f;
    public float fireRate = 0.5f;
    public int maxAmmo = 20;
    public float reloadTime = 2f;
    public float recoilForce = 100f;




    private Vector3 localScale;
    private AudioSource audioSource;
    private float nextFireTime = 0f;
    private int currentAmmo;
    private bool isReloading = false;
    private GameObject owner;
    private float horizontal;
    private bool isFacingRight = true;
    private PlayerMovement playerMovement;

    private bool isMouseRight = true;

    public GameObject bullet;

    private void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();



        // Get the mouse position in world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the gun to the mouse pointer
        Vector2 direction = (mousePos - transform.position).normalized;

        // Set the gun's rotation to face the mouse pointer
        transform.right = direction;

        // // Check if the local scale needs to be flipped
        // if (playerScaleX < 0f)
        // {
        //     transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        // }

        if (mousePos.x > transform.position.x)
        {
            isMouseRight = true;
        }
        else
        {
            isMouseRight = false;
        }

        if (Input.GetButton("Fire1"))
        {
            Fire();
            Debug.Log("Fire pressed");
        }


    }



    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        currentAmmo = maxAmmo;
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void SetOwner(GameObject newOwner)
    {
        owner = newOwner;
    }

    public void Fire()
    {
        if (Time.time < nextFireTime || isReloading || currentAmmo == 0)
        {
            return;
        }

        currentAmmo--;
        nextFireTime = Time.time + fireRate;

        // Play firing sound
        audioSource.Play();

        // Spawn bullet and set its velocity
        //GameObject bullet = Instantiate(bulletPrefab, 1 * (transform.position + new Vector3(1, 0, 0)), transform.rotation);

        if (isMouseRight == true)
        {
            bullet = Instantiate(bulletPrefab, 1 * (transform.position + new Vector3(1, 0, 0)), transform.rotation);
            //PlayerRB.AddForce(-transform.right * recoilForce, ForceMode2D.Impulse);
        }
        else
        {
            bullet = Instantiate(bulletPrefab, 1 * (transform.position + new Vector3(-1, 0, 0)), transform.rotation);
            //PlayerRB.AddForce(transform.right * recoilForce, ForceMode2D.Impulse);
        }
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;

        // Set bullet owner
        BulletController bulletController = bullet.GetComponent<BulletController>();



        if (bulletController != null)
        {
            bulletController.SetOwner(owner);
        }
        Debug.Log("firing");
        // Check if out of ammo
        if (currentAmmo == 0)
        {
            Reload();
        }

        playerMovement.Recoil(recoilForce);


    }

    public void Reload()
    {
        if (isReloading)
        {
            return;
        }

        isReloading = true;
        Invoke("FinishReload", reloadTime);
    }

    private void FinishReload()
    {
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
