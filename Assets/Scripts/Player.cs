using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float balance;

    public TMP_Text balanceText;

    private GameManager gameManager;

    public float Balance { get => balance; set => balance = value; }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        Balance = 10;
        balanceText.text = "Your balance: " + balance.ToString() + "$";
    }

    private void OnEnable()
    {
        gameManager.OnStartPlaying += StartPlaying;
        gameManager.OnRetireBet += EndBet;
    }

    private void OnDisable()
    {
        gameManager.OnStartPlaying -= StartPlaying;
        gameManager.OnRetireBet -= EndBet;
    }

    public void StartPlaying(float bet, float multiplier)
    {
        Balance -= bet;
        balanceText.text = "Your balance: " + balance.ToString() + "$";
    }

    public void EndBet(float bet,float multiplier)
    {
        Balance += bet * multiplier;
        balanceText.text = "Your balance: " + balance.ToString() + "$";
    }
}
