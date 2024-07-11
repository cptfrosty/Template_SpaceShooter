using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
