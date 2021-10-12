using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRotationController : MonoBehaviour
{
    #region Fields

    private Transform player;

    #endregion

    #region Methods

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(player);
        Quaternion rotation = transform.rotation;
        rotation.x = 0;
        rotation.z = 0;
        transform.rotation = rotation;
    }

    #endregion
}
