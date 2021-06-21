using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpGiver : MonoBehaviour
{
    private readonly int _healthAmount = 30;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.TryGetComponent<Player>(out Player player))
        {
            player.AddHealth(_healthAmount, out bool canDestroy);
            if (canDestroy)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
