using UnityEngine;

public class GameSaver
{
	private string pointsKey = "points";
	private string energyKey = "energy";

	public void Save(GameValues gameValues)
	{
		PlayerPrefs.SetInt(pointsKey, gameValues.points);
		PlayerPrefs.SetInt(energyKey, gameValues.energy);
		PlayerPrefs.Save();
	}

	public bool CheckSaves()
	{
		if (PlayerPrefs.HasKey(pointsKey) == false && PlayerPrefs.HasKey(energyKey) == false)
			return false;
		else
			return true;
	}

	public GameValues Load()
	{
		GameValues gameValues;
		gameValues.points = PlayerPrefs.GetInt(pointsKey);
		gameValues.energy = PlayerPrefs.GetInt(energyKey);
		return gameValues;
	}

	public void DeleteAll()
	{
		PlayerPrefs.DeleteAll();
	}
}
