using UnityEngine;

public class PlayerMovementBorder : MonoBehaviour
{
    #region Methods

    private void Start()
    {
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"));
        Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("MagicProjectiles"));
    }

    #endregion
}
