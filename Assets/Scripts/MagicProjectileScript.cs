using UnityEngine;
using System.Collections;
 
public class MagicProjectileScript : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject impactParticle;
    [SerializeField] private GameObject projectileParticle;
    [SerializeField] private GameObject muzzleParticle;
    [SerializeField] private float magicProjectileLifetime = 1.7f;
    [SerializeField] private float impactParticleLifetime = 2f;
    [SerializeField] private float muzzleParticleLifetime = 1.5f;

    private bool hasCollided = false;

    #endregion

    #region Methods

    private void Start()
    {
        InstantiateProjectile();
        Destroy(gameObject, magicProjectileLifetime);   // self-destruction
    }
 
    private void OnCollisionEnter(Collision collision)
    {
        if (!hasCollided)
        {
            hasCollided = true;
            impactParticle = Instantiate(impactParticle, transform.position, Quaternion.identity);

            Destroy(impactParticle, impactParticleLifetime);
            Destroy(gameObject);			
        }
    }

    private void InstantiateProjectile()
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