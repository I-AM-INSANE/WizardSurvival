using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
 
public class MagicProjectile : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject impactParticlePrefab;
    [SerializeField] private GameObject projectileParticlePrefab;
    [SerializeField] private GameObject muzzleParticlePrefab;
    [SerializeField] private int damage;
    [SerializeField] private int projectileSpeed = 500;
    [SerializeField] private float impactParticleLifetime = 2f;
    [SerializeField] private float muzzleParticleLifetime = 1.5f;

    private Vector3 startPosition;
    private PlayerStats playerStats;

    #endregion

    #region Methods

    private void OnEnable()
    {
        playerStats = FindObjectOfType<PlayerStats>();
    }

    private void Start()
    {
        startPosition = transform.position;
        InstantiateProjectileParticle();
    }

    private void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) > playerStats.AttackRange)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject impactParticle = Instantiate(impactParticlePrefab, transform.position, Quaternion.identity);
        TryApplyDamage(collision);
        Destroy(impactParticle, impactParticleLifetime);
        Destroy(gameObject);			
    }

    public void Launch(Vector3 pointToShoot)
    {
        transform.LookAt(pointToShoot);
        GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed, ForceMode.Acceleration);
    }

    private void TryApplyDamage(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IDamageable idamageable))
        {
            idamageable.TakeDamage(damage + playerStats.BaseDamage);
        }
    }

    private void InstantiateProjectileParticle()
    {
        GameObject projectileParticle = Instantiate(projectileParticlePrefab, transform.position, transform.rotation);
        projectileParticle.transform.parent = transform;
        if (muzzleParticlePrefab != null)
        {
            GameObject muzzleParticle = Instantiate(muzzleParticlePrefab, transform.position, transform.rotation);
            Destroy(muzzleParticle, muzzleParticleLifetime);
        }
    }

    #endregion
}