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

    [Header("Adjustable Variables")]
    [SerializeField] private float beamEndOffset = 1f; //How far from the raycast hit point the end effect is positioned
    [SerializeField] private float textureScrollSpeed = 4f; //How fast the texture scrolls along the beam
    [SerializeField] private float textureLengthScale = 12; //Length of the beam texture

    private int currentBeam = 2;
    private Vector3 targetPosition;
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
            targetPosition = targetFinder.Target.transform.position;
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
        line.positionCount = 2;
        line.SetPosition(0, projectileSpawnPoint.position);
        line.SetPosition(1, targetPosition);

        beamStart.transform.position = projectileSpawnPoint.position;
        beamEnd.transform.position = targetFinder.Target.transform.position;

        //line.SetPosition(1, targetPosition);

        beamStart.transform.LookAt(beamEnd.transform.position);
        beamEnd.transform.LookAt(beamStart.transform.position);

        //float distance = Vector3.Distance(projectileSpawnPoint.position, targetPosition);
        //line.sharedMaterial.mainTextureScale = new Vector2(distance / textureLengthScale, 1);
        //line.sharedMaterial.mainTextureOffset -= new Vector2(Time.deltaTime * textureScrollSpeed, 0);
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
