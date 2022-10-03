using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private bool _isActive = true;
    private Coroutine _defeat;
    [HideInInspector] public UnityEvent<bool> OnActive;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    private Color _sratrColor;


    private void Awake() {
        _sratrColor = _spriteRenderer.color;
    }

    public void Die() {
        SetActive(false);

        if (_defeat == null)
            _defeat = StartCoroutine(Defeat(0.5f));

        GameManager.Instance.LaunchDefeat();
    }

    public void SetActive(bool enabled) {
        _isActive = enabled;
        OnActive.Invoke(enabled);
        if (enabled) {
            ResetPlayer();
        }
    }

    public void Subscribe(UnityAction<bool> action) {
        OnActive.AddListener(action);
    }

    private IEnumerator Defeat(float time) {
        Color colorNew = _spriteRenderer.color;
        colorNew.a = 0;

        for (float i = 0; i < time; i += Time.deltaTime) {
            _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, colorNew, i / time);
            yield return null;
        }
    }

    private void ResetPlayer() {
        _spriteRenderer.color = _sratrColor;
        if(_defeat != null) {
            StopCoroutine(_defeat);
            _defeat = null;
        }
    }
}
