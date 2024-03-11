using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform cardsParent; // Assignez un objet parent dans l'UI pour organiser les cartes affichées
    public Transform cardsPanel;
    public Image mainDeckVisual; // Représentation visuelle du Main Deck
    public Text mainDeckCounter; // Texte pour afficher le nombre de cartes restantes

    //private Card selectedCard; // Carte sélectionnée

    private List<Card> deck = new List<Card>();
   
   // private Vector3 startAnimationPosition; // Position initiale pour l'animation des cartes

     void Start()
    {
        GenerateDeck();
        UpdateMainDeckVisual();
        DisplayCards();
    }

    void UpdateMainDeckVisual()
    {
        // Mettre à jour la couleur et le compteur du Main Deck
        mainDeckVisual.color = Color.grey; // Couleur spécifique pour le Main Deck
        mainDeckCounter.text = deck.Count.ToString(); // Afficher le nombre de cartes restantes
    }

    void GenerateDeck()
    {
        // Exemple : Générer un deck de cartes avec des numéros et des couleurs aléatoires
        for (int i = 0; i < 10; i++) // Générer 10 cartes pour cet exemple
        {
            deck.Add(new Card { number = Random.Range(1, 11), color = new Color(Random.value, Random.value, Random.value) });
        }
    }

    void DisplayCards()
    {
       
        for (int i = 0; i < 3; i++) // Afficher 3 cartes
        {

            if (deck.Count > 0)
            {
                Card card = deck[0]; // Prendre la première carte
                deck.RemoveAt(0); // Retirer cette carte du deck

                GameObject cardGO = Instantiate(cardPrefab, cardsPanel);
                cardGO.GetComponent<Image>().color = card.color; // Assigner la couleur aléatoire

                Text textComponent = cardGO.GetComponentInChildren<Text>();
                textComponent.text = card.number.ToString(); // Assigner le numéro aléatoire

                RectTransform rt = cardGO.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(100, 150); // Taille de la carte
            }
            
        }
        UpdateMainDeckVisual(); // Mettre à jour le visuel du Main Deck après avoir tiré les cartes
    }

    // selectionner une carte en clickant dessus et la déplacer au milieu du canvas.
    
 
}



/* void Start()
    {
        startAnimationPosition = mainDeckVisual.transform.position; // Position du Main Deck
        GenerateDeck();
        UpdateMainDeckVisual();
        StartCoroutine(DisplayInitialCardsWithAnimation());
    }

    void GenerateDeck()
    {
        for (int i = 0; i < 50; i++)
        {
            deck.Add(new Card { number = Random.Range(1, 11), color = new Color(Random.value, Random.value, Random.value) });
        }
    }

    IEnumerator DisplayInitialCardsWithAnimation()
    {
        for (int i = 0; i < 3; i++)
        {
            if (deck.Count > 0)
            {
                Card card = deck[0];
                deck.RemoveAt(0);
                GameObject cardGO = Instantiate(cardPrefab, startAnimationPosition, Quaternion.identity, cardsPanel);
                cardGO.GetComponent<Image>().color = card.color;
                Text textComponent = cardGO.GetComponentInChildren<Text>();
                textComponent.text = card.number.ToString();
                RectTransform rt = cardGO.GetComponent<RectTransform>();
                rt.sizeDelta = new Vector2(100, 150);

                // Animer la carte vers sa position finale dans le cardsPanel
                Vector3 finalPosition = cardsPanel.transform.position + new Vector3(i * 2, -1, 0); // Ajustez selon le layout
                yield return StartCoroutine(MoveCardToPosition(cardGO.transform, finalPosition));

                UpdateMainDeckVisual();
            }
            yield return new WaitForSeconds(0.5f); // Délai entre les animations des cartes
        }
    }

    IEnumerator MoveCardToPosition(Transform cardTransform, Vector3 finalPosition)
    {
        float timeToMove = 1.0f;
        float elapsedTime = 0;

        Vector3 startingPos = cardTransform.position;
        while (elapsedTime < timeToMove)
        {
            cardTransform.position = Vector3.Lerp(startingPos, finalPosition, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cardTransform.position = finalPosition; // Assurez-vous que la carte atteint la position finale
    }

    void UpdateMainDeckVisual()
    {
        mainDeckVisual.color = Color.grey;
        mainDeckCounter.text = deck.Count.ToString();
    }

} */