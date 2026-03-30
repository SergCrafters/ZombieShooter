using UnityEngine;

public class PlayerHealth : Health
{
    protected override void OnDeath()
    {
        Time.timeScale = 0;
        base.OnDeath();
    }
}
