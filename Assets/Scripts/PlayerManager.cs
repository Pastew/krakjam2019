﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private int activePlayer;
    public Player[] players;
    private int deadPlayers = 0;

    void Start()
    {

        if (players.Length != 2 || players[0] == null || players[1] == null)
            Debug.LogError("Setup players in player manager");

        activePlayer = 0;
        players[activePlayer].gameObject.SetActive(true);
        players[1].gameObject.SetActive(false);
    }

    public void SwitchPlayers()
    {
        players[activePlayer].gameObject.SetActive(false);

        activePlayer++;
        if (activePlayer >= 2)
            activePlayer = 0;

        players[activePlayer].gameObject.SetActive(true);
        print("Activated player: " + players[activePlayer].name);
    }

    public Player GetActivePlayer()
    {
        return players[activePlayer];
    }

    public Player GetInactivePlayer()
    {
        int inactivePlayerIndex = activePlayer + 1;
        if (inactivePlayerIndex >= 2)
            inactivePlayerIndex = 0;
        return players[inactivePlayerIndex];
    }

    public void GetDamage(int damage)
    {
        Debug.Log("Get damage: " + damage);
        GetActivePlayer().GetDamage(damage);
    }

    internal void playerLose(Player player)
    {
        deadPlayers++;
        if (deadPlayers >= 2)
            SceneManager.LoadScene(0);

        else
        {
            SwitchPlayers();
            FindObjectOfType<Timer>().DisableTimer();
        }
    }

    public void InDarkArea()
    {
        Invoke("ScaredDamage", 5f);
    }

    public void InBrightArea()
    {
        CancelInvoke("ScaredDamage");
    }

    void ScaredDamage()
    {
        GetDamage(1);
        Invoke("ScaredDamage", 0.2f);
    }
}
