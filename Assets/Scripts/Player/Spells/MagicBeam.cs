using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MagicBeam : MonoBehaviour 
{

    #region Fields

    [SerializeField] private Transform projectileSpawnPoint;

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

    private void Update()
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
        Vector3 attackDirection = targetFinder.Target.transform.position - projectileSpawnPoint.position;
        ShootBeamInDirection(attackDirection);
        // PauseBetweenDamage()
        // damage = 25 per sec
    }

    void ShootBeamInDirection(Vector3 attackDirection)
    {
        float halfColliderHeight = target.GetComponent<CapsuleCollider>().height / 2;
        line.positionCount = 2;
        line.SetPosition(0, projectileSpawnPoint.position);
        line.SetPosition(1, target.position + new Vector3(0, halfColliderHeight, 0));

        beamStart.transform.position = projectileSpawnPoint.position;
        beamEnd.transform.position = target.position + new Vector3(0, halfColliderHeight, 0);

        beamStart.transform.LookAt(beamEnd.transform.position);
        beamEnd.transform.LookAt(beamStart.transform.position);
    }

    private void DestroyBeam()
    {
        Destroy(beamStart);
        Destroy(beamEnd);
        Destroy(beam);
    }

    #endregion

    //void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        beamStart = Instantiate(beamStartPrefabs[currentBeam], new Vector3(0, 0, 0), Quaternion.identity);
    //        beamEnd = Instantiate(beamEndPrefabs[currentBeam], new Vector3(0, 0, 0), Quaternion.identity);
    //        beam = Instantiate(beamLineRendererPrefabs[currentBeam], new Vector3(0, 0, 0), Quaternion.identity);
    //        line = beam.GetComponent<LineRenderer>();
    //    }
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        Destroy(beamStart);
    //        Destroy(beamEnd);
    //        Destroy(beam);
    //    }

    //    if (Input.GetMouseButton(0))
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //        if (Physics.Raycast(ray.origin, ray.direction, out hit))
    //        {
    //            Vector3 tdir = hit.point - transform.position;
    //            ShootBeamInDirection(transform.position, tdir);
    //        }
    //    }
    //}
}
