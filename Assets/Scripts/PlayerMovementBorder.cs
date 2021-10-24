using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBorder : MonoBehaviour
{
    #region Methods

    private void Start()
    {
        Physics.IgnoreLayerCollision(gameObject.layer, FindObjectOfType<Enemy>().gameObject.layer);
        Physics.IgnoreLayerCollision(gameObject.layer, 0);
    }

    #endregion
}
