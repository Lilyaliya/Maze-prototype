using System;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [Header("Timer")]
    [SerializeField]private float _timerValue;
    [SerializeField] private Text _timerView;
    [Header("Object")]
    [SerializeField] private Player _player;
    [SerializeField] private Exit _exit;

    private float _timer  = 0;
    private bool _gameIsEnded;
    private void Awake()
    {
        _timer = _timerValue;
        _timerView.text = $"{_timerValue:F1}";

    }
    private void Start()
    {
        _player.Enable();
        _exit.CLose();
    }
    private void Update()
    {
        if (_gameIsEnded)
            return;
        TimerTick();
        TryCompleteLevel();
        LookAtPlayerHealth();
        LookAtPlayerInventory();
    }
    private void TryCompleteLevel()
    {
        var flatExitPosition = new Vector2(_exit.transform.position.x, _exit.transform.position.z);
        var playerExitPosition = new Vector2(_player.transform.position.x, _player.transform.position.z);
        if (flatExitPosition == playerExitPosition)
            Victory();
    }
    private void LookAtPlayerInventory()
    {
        if (_player.HasKey)
            _exit.Open();
        //_exit.Open();

    }
    private void TimerTick()
    {
        _timer -= Time.deltaTime;
        _timerView.text = $"{_timer:F1}";
        if (_timer <= 0)
            Lose();
    }

    private void Lose()
    {
        _gameIsEnded = true;
        _player.Disable();
        Debug.LogError(message: "Lose!");
    }
    private void Victory()
    {
        if (!_player.HasKey)
            return;
        _gameIsEnded = true;
        _player.Disable();
        Debug.LogError(message: "Victory!");
    }

    private void LookAtPlayerHealth()
    {
        if (_player.ISAlive)
            return;
        Lose();
        Destroy(_player.gameObject);
    }
}
