using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class GameController : MonoBehaviour
{
    public List<Button> btns = new List<Button>();
    [SerializeField]
    private Sprite bgImage;
    public Sprite[] puzzles; 
    public List<Sprite> gamePuzzles = new  List<Sprite>();
    private bool FirstGuess,SecondGuess;
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex , secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;
    public GameObject Win_ui;
    private int blueCryst = 0;
    private int greenCryst = 0;
    public Text bluecrystText;

    private void Awake()
    {
        puzzles = Resources.LoadAll<Sprite>("Sprites");
    }
    private void Start()
    {
        GetButtons();
        AddListeners();
      
        AddGamePuzzles();
        shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count /2 ;
        CheckifTheGameIsFinished();
        UpdateCrystText();



    }
    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }



    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0; 
        for (int i = 0;i < looper;i++) { 
            if (index == looper /2)
            {
                index = 0; 

            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }




    void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(()=>PickAPuzzle());
            
        }

    }
    public void PickAPuzzle()
    {
       
        if (!FirstGuess)
        {
            FirstGuess = true; 
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite= gamePuzzles[firstGuessIndex];
            btns[firstGuessIndex].interactable = false;

        }
        else if (!SecondGuess)
        {
            SecondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name; 
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];
            countGuesses++;
            btns[secondGuessIndex].interactable = false;
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
        
    }
    IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(1f);
        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            btns[firstGuessIndex].image.color = new Color(1, 1, 1, 0.5f);
            btns[secondGuessIndex].image.color = new Color(1, 1, 1, 0.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;
            yield return new WaitForSeconds(.5f);
            // btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            //btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            blueCryst= blueCryst+10;
            UpdateCrystText();
            CheckifTheGameIsFinished();


        }
        else
        {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
            btns[firstGuessIndex].interactable = true;
            btns[secondGuessIndex].interactable = true;
        }
        yield return new WaitForSeconds(.5f);
        SecondGuess = FirstGuess = false ;

    }
    void CheckifTheGameIsFinished()
    {
        countCorrectGuesses++; 
        if (countCorrectGuesses > gameGuesses)
        {
            if (Win_ui == null)
            {
                Debug.LogError("TextMeshPro Text component is not assigned!");
                return;
            }
            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);
            HidePuzzles();
            Win_ui.gameObject.SetActive(true);
            
            Debug.Log("Game finished");
            
        }
    }

    void shuffle(List<Sprite> list)
    {
        for(int i =0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i]= list[randomIndex];
            list[randomIndex]= temp;  
        }
    }
    private void UpdateCrystText()
    {

        if (bluecrystText != null)
        {
            bluecrystText.text = blueCryst.ToString();
        }
        else
        {
            Debug.LogError("bluecrystText is not assigned in the Unity Editor!");
        }
    }
    private void HidePuzzles()
    {
        this.GetComponent<AddButtons>().puzzleField.gameObject.SetActive(false);
    }


}
