using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject projectileForSpawn;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private float projectileSpeed = 1000f;
    [SerializeField] private float reloadTime;

    private Vector3 pointToShoot;
    private PlayerAim playerAim;
    private float inputFire1;
    private bool isReloading = false;

    #endregion

    #region Methods

    private void Start()
    {
        playerAim = FindObjectOfType<PlayerAim>();
    }

    private void Update()
    {
        inputFire1 = Input.GetAxis("Fire1");
    }

    private void FixedUpdate()
    {
        if (!isReloading && inputFire1 > 0)
            Shoot();
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectileForSpawn, spawnPosition.position, Quaternion.identity);
        pointToShoot = playerAim.GetPointToShoot();
        projectile.transform.LookAt(pointToShoot);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * projectileSpeed, ForceMode.Acceleration);
        StartCoroutine(ReloadRoutine());
    }

    private IEnumerator ReloadRoutine()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }

    #endregion Methods
}
