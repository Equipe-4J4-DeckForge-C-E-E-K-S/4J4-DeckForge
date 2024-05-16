using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Import the TMPro namespace
using UnityEngine.UI; // Import the UI namespace

public class ScriptBonusHPDEF : MonoBehaviour
{
    public float vie;
    public float defense;
    public float defenseInitiale;
    public float attaque;

    public bool typeBasique;
    public bool typeEau;
    public bool typeFeu;
    public bool typePlante;

    public TextMeshProUGUI playerCueText; // Declare a TextMeshProUGUI object

    public Button increaseHPButton; // Declare a Button object for the HP button
    public Button increaseDefenseButton; // Declare a Button object for the Defense button

    public Image playerChoiceImage; // Declare an Image object for the player's choice
    public Sprite heartSprite; // Declare a Sprite object for the heart image
    public Sprite shieldSprite; // Declare a Sprite object for the shield image

    private bool hasPlayerChosen = false; // Flag to track if the player has made a choice

    // Start is called before the first frame update
    void Start()
    {
        defenseInitiale = defense;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to be called when the player chooses to increase HP
    public void IncreaseHP()
    {
        if (!hasPlayerChosen)
        {
            vie += 10; // Example increase in HP
            playerCueText.text = "HP +10"; // Set the text
            playerChoiceImage.sprite = heartSprite; // Set the image to the heart sprite
            hasPlayerChosen = true; // Set the flag to true
            increaseHPButton.interactable = false; // Disable the HP button
            increaseDefenseButton.interactable = false; // Disable the Defense button
        }
    }

    // Function to be called when the player chooses to increase Defense
    public void IncreaseDefense()
    {
        if (!hasPlayerChosen)
        {
            defense += 5; // Example increase in Defense
            playerCueText.text = "Defense +5"; // Set the text
            playerChoiceImage.sprite = shieldSprite; // Set the image to the shield sprite
            hasPlayerChosen = true; // Set the flag to true
            increaseHPButton.interactable = false; // Disable the HP button
            increaseDefenseButton.interactable = false; // Disable the Defense button
        }
    }

    // Function to be called when the player clicks the "Continue" button to transition to the main game scene
    public void ContinueToMainGame()
    {
        SceneManager.LoadScene("DECKJEU"); // Load your main game scene
    }
}