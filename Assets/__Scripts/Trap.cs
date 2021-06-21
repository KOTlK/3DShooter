using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private readonly int _healthAmount = 40;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.TryGetComponent<Player>(out Player player))
        {
            player.ApplyDamage(_healthAmount);
            Destroy(this.gameObject);
        }
    }
}
