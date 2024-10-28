using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public GameObject bulletPrefab; // The bullet prefab to instantiate
    public Transform bulletSpawn; // The position where bullets will be spawned
    public float bulletSpeed = 20f; // The speed of the bullet
    public LineRenderer laserLine; // The LineRenderer for the laser
    public float laserMaxDistance = 50f; // The maximum distance the laser can reach

    void Start()
    {
        // Make sure the LineRenderer component is assigned
        if (laserLine == null)
        {
            laserLine = GetComponent<LineRenderer>();
        }

        // Initialize the LineRenderer if needed
        laserLine.enabled = true;
        laserLine.startWidth = 0.05f; // Set the laser line width
        laserLine.endWidth = 0.05f;
    }

    void Update()
    {
        // Check if the right mouse button is clicked
        if (Input.GetMouseButtonDown(1)) // 1 is the right mouse button
        {
            Shoot();
        }

        // Update the laser every frame
        UpdateLaser();
    }

    void Shoot()
    {
        // Instantiate the bullet at the spawn position
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Get the Rigidbody component and set its velocity
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = bulletSpawn.forward * bulletSpeed; // Set the bullet's velocity
        }
    }

    void UpdateLaser()
    {
        // Set the start position of the laser (at the bullet spawn point)
        laserLine.SetPosition(0, bulletSpawn.position);

        // Cast a ray from the bullet spawn point forward to determine where the laser should end
        RaycastHit hit;
        if (Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, laserMaxDistance))
        {
            // If the ray hits something, set the end of the laser at the hit point
            laserLine.SetPosition(1, hit.point);
        }
        else
        {
            // If the ray doesn't hit anything, extend the laser to its max distance
            laserLine.SetPosition(1, bulletSpawn.position + bulletSpawn.forward * laserMaxDistance);
        }
    }
}
