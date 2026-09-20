using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradeCardVisual : MonoBehaviour
{
    [SerializeField] private UpgradeCardDatabase upgradeCardDatabase;
    [SerializeField] private List<Text> cardsDescriptions;
    [SerializeField] private List<Image> cardsIcons;
    [SerializeField] private List<Image> currentBorders;
    [SerializeField] private List<Sprite> rarityBorders;
    [SerializeField] private float epicChanceModifier = 5;
    [SerializeField] private int maxCardsCount = 3;
    private Rarity _currentCardRarity;
    private float _playerLuck;
    private List<float> _valuesModifier;

    private void Awake()
    {
        _valuesModifier = new List<float>();
    }

    private void OnEnable()
    {
        ExperienceManager.onBarFilledUp += ExperienceManager_onBarFilledUp;
    }

    private void ExperienceManager_onBarFilledUp(object sender, System.EventArgs e)
    {
        SetRarityBordersForAllCards();
        SetAllCardVisual();
    }

    private void SetAllCardVisual()
    {
        var card1 = GetCardAndSetCardVisual(Random.Range(100, 109), 0);
        var card2 = GetCardAndSetCardVisual(Random.Range(100, 109), 1);
        var card3 = GetCardAndSetCardVisual(Random.Range(100, 109), 2);
        if (card1 == card2 || card1 == card3 || card2 == card3)
            SetAllCardVisual();
        else
            _valuesModifier.Clear();
    }

    private void Start()
    {
        _playerLuck = Player.Instance.Luck;
    }

    private UpgradeCard GetCard(int cardId)
    {
        return (upgradeCardDatabase.Items.FirstOrDefault(card => card.Id == cardId));
    }


    private UpgradeCard GetCardAndSetCardVisual(int cardId, int cardCount)
    {
        var currentCard = GetCard(cardId);
        SetCardVisual(currentCard, cardCount);
        return currentCard;
    }

    private void SetCardVisual(UpgradeCard currentCard, int cardCount)
    {
        float _value = currentCard.Value * _valuesModifier[cardCount];
        cardsDescriptions[cardCount].text = currentCard.Description +
            $"\n {currentCard.Component} + {_value}";
        cardsIcons[cardCount].sprite = currentCard.Icon;
    }

    private Sprite GetRarityForOneCard()
    {
        int _rand = Random.Range(0, 100);

        if (_rand <= _playerLuck)
            _currentCardRarity = Rarity.legendary;
        else if (_rand <= _playerLuck * epicChanceModifier)
            _currentCardRarity = Rarity.epic;
        else
            _currentCardRarity = Rarity.common;

        return rarityBorders[(int)_currentCardRarity];
    }

    private float GetModifierByRarity(Rarity currentRarity)
    {
        switch (currentRarity)
        {
            case Rarity.common:
                return 1f;
            case Rarity.epic:
                return 1.5f;
            case Rarity.legendary:
                return 2f;
            default:
                return 1f;
        }
    }

    private void SetRarityBordersForAllCards()
    {
        for (int currentCardNumber = 0; currentCardNumber < maxCardsCount; currentCardNumber++)
        {
            currentBorders[currentCardNumber].sprite = GetRarityForOneCard();
            _valuesModifier.Add(GetModifierByRarity(_currentCardRarity));
        }
    }
}

public enum Rarity
{
    legendary,
    epic,
    common
}