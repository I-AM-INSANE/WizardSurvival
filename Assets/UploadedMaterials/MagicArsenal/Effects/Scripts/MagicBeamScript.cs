using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MagicBeamScript : MonoBehaviour {

    [Header("Prefabs")]
    [SerializeField] private GameObject[] beamLineRendererPrefab;
    [SerializeField] private GameObject[] beamStartPrefab;
    [SerializeField] private GameObject[] beamEndPrefab;

    [Header("Adjustable Variables")]
    [SerializeField] private float beamEndOffset = 1f; //How far from the raycast hit point the end effect is positioned
    [SerializeField] private float textureScrollSpeed = 4f; //How fast the texture scrolls along the beam
    [SerializeField] private float textureLengthScale = 12; //Length of the beam texture

    private int currentBeam = 2;
    private GameObject beamStart;
    private GameObject beamEnd;
    private GameObject beam;
    private LineRenderer line;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            beamStart = Instantiate(beamStartPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity);
            beamEnd = Instantiate(beamEndPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity);
            beam = Instantiate(beamLineRendererPrefab[currentBeam], new Vector3(0, 0, 0), Quaternion.identity);
            line = beam.GetComponent<LineRenderer>();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(beamStart);
            Destroy(beamEnd);
            Destroy(beam);
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Vector3 tdir = hit.point - transform.position;
                ShootBeamInDir(transform.position, tdir);
            }
        }
    }

    void ShootBeamInDir(Vector3 start, Vector3 dir)
    {
        line.positionCount = 2;
        line.SetPosition(0, start);
        beamStart.transform.position = start;

        Vector3 end = Vector3.zero;
        RaycastHit hit;
        if (Physics.Raycast(start, dir, out hit))
            end = hit.point - (dir.normalized * beamEndOffset);
        else
            end = transform.position + (dir * 100);

        beamEnd.transform.position = end;
        line.SetPosition(1, end);

        beamStart.transform.LookAt(beamEnd.transform.position);
        beamEnd.transform.LookAt(beamStart.transform.position);

        float distance = Vector3.Distance(start, end);
        line.sharedMaterial.mainTextureScale = new Vector2(distance / textureLengthScale, 1);
        line.sharedMaterial.mainTextureOffset -= new Vector2(Time.deltaTime * textureScrollSpeed, 0);
    }
}
