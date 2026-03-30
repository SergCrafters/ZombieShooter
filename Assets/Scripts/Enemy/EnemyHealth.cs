using UnityEngine;

public class EnemyHealth : Health
{
    protected override void OnDeath()
    {
        base.OnDeath();
        Destroy(gameObject);
    }
}
