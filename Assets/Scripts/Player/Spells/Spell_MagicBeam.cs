using UnityEngine;

public class Spell_MagicBeam : Base_MagicSpell 
{

    #region Fields

    [SerializeField] private Transform projectileSpawnPoint;
    [SerializeField] private LayerMask objToHit;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] beamLineRendererPrefabs;
    [SerializeField] private GameObject[] beamStartPrefabs;
    [SerializeField] private GameObject[] beamEndPrefabs;

    private int currentBeam = 2;
    private Transform target;
    private GameObject beamStart;
    private GameObject beamEnd;
    private GameObject beam;
    private LineRenderer line;
    private TargetFinder targetFinder;

    #endregion

    #region Methods

    private void Start()
    {
        targetFinder = GetComponent<TargetFinder>();
    }

    private void FixedUpdate()
    {
        if (targetFinder.Target != null)
        {
            target = targetFinder.Target.transform;
            if (beamStart == null)
            {
                InstantianeBeam();
            }
            BeamAttack();
        }
        else
            DestroyBeam();
    }

    private void InstantianeBeam()
    {
        beamStart = Instantiate(beamStartPrefabs[currentBeam], projectileSpawnPoint.position, Quaternion.identity);
        beamEnd = Instantiate(beamEndPrefabs[currentBeam], targetFinder.Target.transform.position, Quaternion.identity);
        beam = Instantiate(beamLineRendererPrefabs[currentBeam], projectileSpawnPoint.position, Quaternion.identity);
        line = beam.GetComponent<LineRenderer>();
    }

    private void BeamAttack()
    {
        bool endpointIsEnemy = false;
        Vector3 endpoint = GetEndpoint(ref endpointIsEnemy);
        ShootBeamInDirection(endpoint);
        if (endpointIsEnemy == true)
            ApplyDamage();
    }

    void ShootBeamInDirection(Vector3 endpoint)
    {
        line.positionCount = 2;
        line.SetPosition(0, projectileSpawnPoint.position);
        line.SetPosition(1, endpoint);

        beamStart.transform.position = projectileSpawnPoint.position;
        beamEnd.transform.position = endpoint;

        beamStart.transform.LookAt(beamEnd.transform.position);
        beamEnd.transform.LookAt(beamStart.transform.position);
    }

    private Vector3 GetEndpoint(ref bool endpointIsEnemy)
    {
        Vector3 end;
        Vector3 attackDirection = target.position - projectileSpawnPoint.position;
        Physics.Raycast(projectileSpawnPoint.position, attackDirection, out RaycastHit hit, objToHit);
        end = hit.point;
        if (hit.collider.TryGetComponent(out Enemy enemy))
            endpointIsEnemy = true;

        float halfColliderHeight = target.GetComponent<CapsuleCollider>().height / 2;
        end += new Vector3(0, halfColliderHeight, 0);
        return end;
    }

    private void ApplyDamage()
    {
        target.GetComponent<IDamageable>().TakeDamage(DamagePerSecond * Time.fixedDeltaTime);
    }

    private void DestroyBeam()
    {
        Destroy(beamStart);
        Destroy(beamEnd);
        Destroy(beam);
    }

    #endregion
}
