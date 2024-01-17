using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="GameDatas" , menuName ="Game/datas")]
public class GameDataSo : ScriptableObject
{
    [Header("Difficulty Game Settings")]
    public Difficulty Difficulty;
    public int rows; 
    public int columns;
    [Header("Card Background Image")] // just affichage

    [Header("Grid Layout Variables")]

    public Sprite background;
    public int prefferedTopBottomPadding;
    public Vector2 spacing; 
}
