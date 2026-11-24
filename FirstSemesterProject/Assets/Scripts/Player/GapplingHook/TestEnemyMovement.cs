using UnityEngine;

public class TestEnemyMovement : MonoBehaviour, IEnemyMovement
{
    void IEnemyMovement.SetMovementEnabled(bool enabled)
    {
        this.enabled = enabled;
    }
}
