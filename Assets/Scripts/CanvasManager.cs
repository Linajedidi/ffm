using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public CardCollectionSo collection;
    public GameDataSo easyDatas;
    public GameDataSo normalDatas; 
    public GameDataSo hardDatas;
    GameDataSo gameDatas;
    List<CardController> cardControllers;
    public void Awake()
    {
        cardControllers = new List<CardController>();


        GetGameDatasDifficulty();
        SetCardGridLayoutParams();
        GenerateCards(); 
    }

    private void GenerateCards()
    {
        int cardcount = gameDatas.rows * gameDatas.columns;
        for (int i = 0; i < cardcount; i++)
        {
            GameObject card = Instantiate(cardPrefab,this.transform);
            card.transform.name = "Card ("+ i .ToString() + ")";
            cardControllers.Add(card.GetComponent<CardController>());
        }
    }

    private void SetCardGridLayoutParams()
    {
        CardGridLayout cardGridLayout =this.GetComponent<CardGridLayout>();
        cardGridLayout.topPadding = gameDatas.prefferedTopBottomPadding;
        cardGridLayout.rows = gameDatas.rows;
        cardGridLayout.columns = gameDatas.columns;
        cardGridLayout.spacing = gameDatas.spacing;

    }

    private void GetGameDatasDifficulty()
    {
        Difficulty difficulty = (Difficulty)PlayerPrefs.GetInt("Difficulty", (int)Difficulty.Normal);
        switch (difficulty)
        {
            case Difficulty.Easy:
                gameDatas = easyDatas; break;
            case Difficulty.Normal: 
                gameDatas = normalDatas; break;
            case Difficulty.Hard: 
                gameDatas = hardDatas; break;
        }
    }

   
}
