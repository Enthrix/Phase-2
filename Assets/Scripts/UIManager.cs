using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    private Image[] _livesImage;

    [SerializeField]
    private Sprite[] _lives;

    [SerializeField]
    private int _life = 3;

    [SerializeField]
    private GameObject _player1GameOverText;

    [SerializeField]
    private GameObject _player2GameOverText;

    [SerializeField]
    private const string winText = "You win";

    [SerializeField]
    private const string loseText = "You lose";


    [SerializeField]
    private GameObject _restartText;

    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private UIManager _uiManager;

    [SerializeField]
    public int ID = 0;

    // Start is called before the first frame update
    void Start()
    {
        _player1GameOverText.SetActive(false);
        _player2GameOverText.SetActive(false);
        _restartText.SetActive(false);

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }
    
    public void Damage()
    {
        _life -= 1;
        _uiManager.UpdateLives(ID, _life);

        if (_life < 1)
        {
            _player1GameOverText.SetActive(false);
            _player2GameOverText.SetActive(false);
            _restartText.SetActive(false);
        }
        else if(_life == 0)
        {
            _player1GameOverText.SetActive(true);
            _player2GameOverText.SetActive(true);
            _restartText.SetActive(true);
        }
    }

    internal void UpdateLives(int lives)
    {
        throw new NotImplementedException();
    }


    public void UpdateLives(int playerId, int points)
    {
        _livesImage[playerId].sprite = _lives[points];
        if (points < 1)
        {
            if (playerId == 1)
            {
                _player1GameOverText.GetComponent<Text>().text = loseText;
                _player2GameOverText.GetComponent<Text>().text = winText;
            }
            else
            {
                _player1GameOverText.GetComponent<Text>().text = winText;
                _player2GameOverText.GetComponent<Text>().text = loseText;
            }
        }
    }
}
