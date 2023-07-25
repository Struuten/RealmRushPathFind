using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;

    public int CurrentBalance { get { return currentBalance; } }

    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplayBalance();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplayBalance();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);

        if (currentBalance < 0)
        {
            ReloadScene();
        }
        UpdateDisplayBalance();
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    void UpdateDisplayBalance()
    {
       displayBalance.text = "Gold: " + currentBalance;
    }
}
