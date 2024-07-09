using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mainText;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] GameObject choiceElement;
    [SerializeField] Transform choiceParent;
    [Space]
    [SerializeField] DialogueZone currentZone;
    [Header("Typing")]
    [SerializeField] float typeSpeed = 0.1f;

    public int currentLine;
    private List<GameObject> btns;

    // Typing 
    private string currentText = "";
    private string displayedStr = "";
    private int currentChar = 0;

    private void Start()
    {
        btns = new List<GameObject>();

        ApplyZone(currentZone);
        StartCoroutine(Typer());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
        {
            // Finish typing first 
            if(currentChar < currentText.Length)
            {
                currentChar = currentText.Length;
                mainText.text = currentText;
                return;
            }


            // Next line if possible 
            if (currentZone.dialogue.Count > currentLine + 1)
            {
                currentLine++;
                currentText = currentZone.dialogue[currentLine];

                // Reset typer variables 
                displayedStr = "";
                currentChar = 0;

                if (currentLine + 1 == currentZone.dialogue.Count)
                {
                    // Generat choices 
                    GenerateChoices();
                }
            }
        }
    }

    public void ApplyZone(DialogueZone zone)
    {
        // Cleanup of old zone 
        currentLine = 0;

        // Cleanup buttons 
        for (int i = btns.Count - 1; i >= 0; i--)
        {
            Destroy(btns[i]);
        }

        btns.Clear();

        if (zone.dialogue.Count > 0)
            currentText = zone.dialogue[0];

        // Reset typer variables 
        displayedStr = "";
        currentChar = 0;

        currentZone = zone;

        nameText.text = zone.name;

        // If only one line of dialogue immediatly generate choices 
        if (zone.dialogue.Count == 0 || zone.dialogue.Count == 1)
            GenerateChoices();
    }

    public void SetNewZoneByIndex(int index )
    {
        // Index correlates with child index which also is 
        // same index as currentZone's choice list 

        ApplyZone(currentZone.choices[index]);
    }

    private void GenerateChoices()
    {
        for (int i = 0; i < currentZone.choices.Count; i ++)
        {
            // Creates a button and applies text 
            GameObject choice = Instantiate(choiceElement, choiceParent);
            choice.GetComponentInChildren<TextMeshProUGUI>().text = currentZone.choices[i].name;

            // Apply button data to let it swap cameras 
            MovementBtn btn = choice.GetComponent<MovementBtn>();
            btn.adventureManager = this;
            btn.currentCam = currentZone.cam;
            btn.targetCam = currentZone.choices[i].cam;


            btns.Add(choice);
        }
    }

    /// <summary>
    /// Constantly types out the currently dialogue 
    /// </summary>
    /// <returns></returns>
    private IEnumerator Typer()
    {

        while(true)
        {
            if(currentChar < currentText.Length)
            {
                print(currentChar >= currentText.Length);
                displayedStr += currentText[currentChar];
                mainText.text = displayedStr;

                currentChar++;
            }
                
            yield return new WaitForSeconds(1.0f / typeSpeed);
        }
    }
}
