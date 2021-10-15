using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject projectileForSpawn;
    [SerializeField] private Transform spawnPosition;

    private Vector3 pointToShoot;
    private PlayerAim playerAim;
    private PlayerStats playerStats;

    #endregion

    #region Methods

    private void Start()
    {
        playerAim = GetComponent<PlayerAim>();
        playerStats = GetComponent<PlayerStats>();
    }

    public void Attack()
    {
        GameObject projectile = Instantiate(projectileForSpawn, spawnPosition.position, Quaternion.identity);
        pointToShoot = playerAim.GetPointToShoot();
        projectile.transform.LookAt(pointToShoot);
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * playerStats.MagicProjectileSpeed, ForceMode.Acceleration);
    }

    #endregion Methods
}
