using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class GetCardById : MonoBehaviour
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
    private List<UpgradeCard> _cards;

    private void Awake()
    {
        _cards = new List<UpgradeCard>();
        _valuesModifier = new List<float>();
    }

    private void Start()
    {
        _playerLuck = Player.Instance.Luck;
        SetRarityBordersForAllCards();
        SetCardVisualById(103, 0);
        SetCardVisualById(104, 1);
        SetCardVisualById(105, 2);
    }

    private void GetCard(int cardId)
    {
        _cards.Add(upgradeCardDatabase.GetCardById(cardId));
    }

    private void SetTextAndIconById(int cardCount)
    {
        float _value = _cards[cardCount].Value * _valuesModifier[cardCount];
        Debug.Log(_cards[cardCount].Value + " и множитель " + _valuesModifier[cardCount]);
        cardsDescriptions[cardCount].text = _cards[cardCount].Description + $"\n {_cards[cardCount].Component} + {_value}";
        cardsIcons[cardCount].sprite = _cards[cardCount].Icon;
    }   

    private void SetCardVisualById(int id, int cardCount)
    {
        GetCard(id);
        SetTextAndIconById(cardCount);
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