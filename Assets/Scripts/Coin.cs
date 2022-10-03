using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _collectedNumber = 1;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.attachedRigidbody) {
            if (collision.attachedRigidbody.GetComponent<Player>()) {
                GameManager.Instance.AddCoins(_collectedNumber);
                gameObject.SetActive(false);
            }
        }
    }
}
