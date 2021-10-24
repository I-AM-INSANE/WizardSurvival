using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    #region Fields

    [SerializeField] private float offsetForRay;    // 7 for "darkMage"
    [SerializeField] private LayerMask ObjToHit;

    private Camera mainCamera;
    private RaycastHit hit;

    #endregion

    #region Methods

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Debug.DrawRay(mainCamera.transform.position + mainCamera.transform.forward * offsetForRay, mainCamera.transform.forward * 100f, Color.red);
    }

    public Vector3 GetPointToShoot()
    {

        if (Physics.Raycast(mainCamera.transform.position + mainCamera.transform.forward * offsetForRay, mainCamera.transform.forward, out hit, 100f, ObjToHit))
            return hit.point;

        return transform.position + transform.forward * 100f;   // if no object to shoot
    }

    #endregion
}
