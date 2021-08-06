using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{

    #region Fields

    [SerializeField] private LayerMask objToHit;

    private RaycastHit hit;

    #endregion

    #region Methods

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.red);
    }

    public Vector3 GetPointToShoot()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 50f, objToHit))
            return hit.point;

        return transform.position + transform.forward * 50;   // if no object to shoot
    }

    #endregion
}
