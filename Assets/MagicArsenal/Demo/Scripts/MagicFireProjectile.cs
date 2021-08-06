using UnityEngine;
using UnityEngine.EventSystems;
public class MagicFireProjectile : MonoBehaviour
{
    RaycastHit hit;
    [SerializeField] private GameObject projectileForSpawn;
    public Transform spawnPosition;
    public float speed = 1000f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
            {
                GameObject projectile = Instantiate(projectileForSpawn, spawnPosition.position, Quaternion.identity);
                projectile.transform.LookAt(hit.point);
                projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed);
                projectile.GetComponent<MagicProjectileScript>().impactNormal = hit.normal;
            }
        }
    }
}