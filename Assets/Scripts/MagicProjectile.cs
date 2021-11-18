using UnityEngine;
 
public class MagicProjectile : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject impactParticle;
    [SerializeField] private GameObject projectileParticle;
    [SerializeField] private GameObject muzzleParticle;
    [SerializeField] private int damage;
    [SerializeField] private int projectileSpeed = 500;
    [SerializeField] private float impactParticleLifetime = 2f;
    [SerializeField] private float muzzleParticleLifetime = 1.5f;

    private Vector3 startPosition;
    private PlayerStats playerStats;

    #endregion

    #region Properties

    public int ProjectileSpeed => projectileSpeed;

    #endregion

    #region Methods

    private void Start()
    {
        startPosition = transform.position;
        playerStats = FindObjectOfType<PlayerStats>();
        InstantiateProjectileParticle();
    }

    private void Update()
    {
        if (Vector3.Distance(startPosition, transform.position) > playerStats.AttackRange)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        impactParticle = Instantiate(impactParticle, transform.position, Quaternion.identity);
        TryApplyDamage(collision);
        Destroy(impactParticle, impactParticleLifetime);
        Destroy(gameObject);			
    }

    public void AddExtraDamage(int extraDamage)
    {
        damage += extraDamage;
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
        projectileParticle = Instantiate(projectileParticle, transform.position, transform.rotation);
        projectileParticle.transform.parent = transform;
        if (muzzleParticle != null)
        {
            muzzleParticle = Instantiate(muzzleParticle, transform.position, transform.rotation);
            Destroy(muzzleParticle, muzzleParticleLifetime);
        }
    }

    #endregion
}