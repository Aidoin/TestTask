using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private int _coinCount; public int CoinCount => _coinCount;
    [SerializeField] private Text _coinsCountText;
    [SerializeField] private Player _player;
    [SerializeField] private int _needToCollectCoins = 10;
    [SerializeField] private List<Coin> _coins;

    [Header("UI")]
    [SerializeField] private GameObject _uiVictoryPanel;
    [SerializeField] private GameObject _uiDefeatPanel;


    private void Awake() {
        if (Instance) {
            Debug.LogError("Reinitialization attempt" + this.GetType());
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    private void Start() {
        Restart();
    }

    public void AddCoins(int count) {
        _coinCount += count;

        if(CoinCount >= _needToCollectCoins) {
            LaunchVictory();
        }

        UpdateTextCoins();
    }

    public void RemoveCoin(int count) {
        if (_coinCount < count) {
            _coinCount = 0;
        } else {
            _coinCount -= count;
        }
        UpdateTextCoins();
    }

    private void UpdateTextCoins() {
        _coinsCountText.text = _coinCount.ToString();
    }

    public void LaunchVictory() {
        _player.SetActive(false);
        Invoke(nameof(ShowScreenVictory), 0.3f  );
    }

    public void LaunchDefeat() {
        _player.SetActive(false);
        Invoke(nameof(ShowScreenDefeat), 0.3f);
    }

    private void ShowScreenVictory() {
        _uiVictoryPanel.SetActive(true);
    }

    private void ShowScreenDefeat() {
        _uiDefeatPanel.SetActive(true);
    }

    public void Restart() {
        _uiVictoryPanel.SetActive(false);
        _uiDefeatPanel.SetActive(false);

        RemoveCoin(_coinCount);

        foreach (var item in _coins) {
            item.gameObject.SetActive(true);
        }
        _player.transform.position = Vector3.zero;
        _player.SetActive(true);
    }
}
