using UnityEngine;
using Pathfinding;
using System;

public class DestinationTargetSetter : MonoBehaviour
{
    #region Fields

    private Transform player;
    private AIDestinationSetter destinationSetter;

    #endregion

    #region Methods

    private void Start()
    {
        player = FindObjectOfType<Player>().transform;
        destinationSetter = GetComponent<AIDestinationSetter>();
    }

    private void Update()
    {
        SetTarget();
    }

    private void SetTarget()
    {
        destinationSetter.target = player;
    }

    #endregion
}
