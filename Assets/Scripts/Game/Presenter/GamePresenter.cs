using System;
using UnityEngine;

[RequireComponent(typeof(GameModel), typeof(GameView))]
public class GamePresenter : MonoBehaviour
{
	[SerializeField] private GameProperties gameProperties;
	private GameModel gameModel;
	private GameView gameView;
	private float sessionTime;
	private Settings settings;

	public Action<int> OnChangePonts;
	public Action<int> OnChangeEnergy;

	private void Start()
	{
		gameModel = GetComponent<GameModel>();
		gameView = GetComponent<GameView>();
		gameModel.Init(this);
		gameView.Init(this);
		settings = gameProperties.GetBaseGameValues();
		LoadGame();
	}

	private void FixedUpdate()
	{
		float time = sessionTime + settings.timeToIncome;
		if (Time.time > time)
		{
			sessionTime += settings.timeToIncome;
			int value = settings.incomePerSec * settings.timeToIncome;
			AddTimeIncome(value);
		}
	}

	public void OnMainButtonClicked()
	{
		GameValues gv = new GameValues();
		int pointsIncome = settings.clickValue * settings.clickModifier;
		gv.points = gameModel.Points + pointsIncome;
		if (settings.isUseBoost)
		{
			gv.points += (int)(gameModel.Points * settings.boostMulty);
		}
		gv.energy = gameModel.Energy - pointsIncome;
		ChangeGameValues(gv);
	}

	private void AddTimeIncome(int value)
	{
		GameValues gv = new GameValues();
		gv.points = gameModel.Points + value;
		gv.energy = gameModel.Energy + settings.timeToIncome * settings.energyIncomeMulty;
		if (gv.energy > settings.maxEnergy)
		{
			gv.energy = settings.maxEnergy;
		}
		ChangeGameValues(gv);
	}

	private void LoadGame()
	{
		GameSaver gs = new GameSaver();
		if (gs.CheckSaves())
		{
			GameValues gv = gs.Load();
			ChangeGameValues(gv);
		}
		else
		{
			GameValues gv = new GameValues();
			gv.energy = settings.startEnergy;
			ChangeGameValues(gv);
		}
	}

	private void ChangeGameValues(GameValues gv)
	{
		OnChangePonts?.Invoke(gv.points);
		OnChangeEnergy?.Invoke(gv.energy);
	}
}
