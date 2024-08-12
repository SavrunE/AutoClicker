using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameProperties", menuName = "GameProperties")]
public class GameProperties : ScriptableObject
{
	[SerializeField] private Settings gameValues = new Settings() { clickValue = 10, clickModifier = 2, incomePerSec = 50, timeToIncome = 3,
	energyIncomeMulty = 10, startEnergy = 7000, maxEnergy = 7000, isUseBoost = true, boostMulty = 0.1f};

	public Settings GetBaseGameValues()
	{
		return gameValues;
	}
}

[Serializable]
public struct Settings
{
	public int clickValue;
	public int clickModifier;
	public int incomePerSec;
	public int timeToIncome;
	public int energyIncomeMulty;
	public int startEnergy;
	public int maxEnergy;
	public bool isUseBoost;
	public float boostMulty;
}

public struct GameValues
{
	public int points;
	public int energy;
}