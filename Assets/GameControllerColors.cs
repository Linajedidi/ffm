
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerColors : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();
    List<int> selectedButtons = new List<int>();
    List<int> randomButtons = new List<int>();
    [SerializeField] int MaxButtons = 5;
    [SerializeField] float coloringFadeTime = 1f;
    [SerializeField] float timeBetweenColoring = 1.5f;
    [SerializeField] Color color = Color.blue;
    [SerializeField] List<Color> randomColorList = new List<Color>();
    public int GemNumber;
    public Text GemText;
    public GameObject congrats;
    private string Win_Scene = "YouWin3";
    private string Lose_Scene = "YouLose";



    void Start()
    {
       
        StartGame();


    }
    void StartGame()
    {
        if (randomButtons.Count >= MaxButtons)
        {
            Winner();
        }
        else
        {
            selectedButtons.Clear();
            RandomButton();
            StartCoroutine(ColorRandomButtons(timeBetweenColoring));


        }
    }

    void Winner()
    {
        EnableAllButtons(false);
        GemNumber += 5;
        UpdateCrystText();
        Debug.Log("you win");
        SceneManager.LoadScene(Win_Scene);

        var oldScore = PlayerPrefs.GetInt("GemNumber", 0);
        PlayerPrefs.SetInt("GemNumber", oldScore + GemNumber);
    }

    private void UpdateCrystText()
    {

        if (GemText != null)
        {
            GemText.text = GemNumber.ToString();

        }
        else
        {
            Debug.LogError("GemNumber is not assigned");
        }
    }


    public void OnButtonClick(int index)
    {

        selectedButtons.Add(index);
        Debug.Log(index);
        StartCoroutine((ColorAfterTime(index, color)));

        CheckAnswers();


    }
    void CheckAnswers()
    {
        if (selectedButtons[selectedButtons.Count - 1] == randomButtons[selectedButtons.Count - 1])
        {
            if (IsFinishedSelecting())
            {
                Debug.Log("Finished");
                
                GemNumber++;
                UpdateCrystText();
                StartGame();

            }
            else
            {
                Debug.Log("Resume");
            }
        }
        else
        {
            Debug.Log("You Lose");
            EnableAllButtons(false);
            SceneManager.LoadScene(Lose_Scene);
        }
    }
    bool IsFinishedSelecting()
    {
        if (selectedButtons.Count == randomButtons.Count)
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void RandomButton()
    {
        int randomButton = Random.Range(0, buttons.Count);
        randomButtons.Add(randomButton);

    }
    IEnumerator ColorAfterTime(int index, Color color)
    {



        Button selectedButton = buttons[index];
        Color defaultColor = selectedButton.image.color;
        selectedButton.image.color = color;
        Debug.Log("Random Button " + (index + 1) + ": " + selectedButton.name);
        yield return new WaitForSeconds(coloringFadeTime);
        selectedButton.image.color = defaultColor;


    }

    IEnumerator ColorRandomButtons(float wait = 0)
    {
        EnableAllButtons(false);
        yield return new WaitForSeconds(wait);
        for (int i = 0; i < randomButtons.Count; i++)
        {

            Color randomColor = randomColorList[Random.Range(0, randomColorList.Count)];
            StartCoroutine(ColorAfterTime(randomButtons[i], randomColor));
            // button interactable
            yield return new WaitForSeconds(timeBetweenColoring);

        }
        EnableAllButtons(true);
    }
    void EnableAllButtons(bool enabled)
    {
        foreach (Button button in buttons)
        {
            button.interactable = enabled;
        }

    }



}
