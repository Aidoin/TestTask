using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.attachedRigidbody) {
            if (collision.attachedRigidbody.GetComponent<Player>() is Player player) {
                player.Die();
            }
        }
    }
}
