using UnityEngine;

public class GameModel : MonoBehaviour
{
	GamePresenter gamePresenter;
	private GameValues gameValues;
	public int Points => gameValues.points;
	public int Energy => gameValues.energy;

	public void Init(GamePresenter gp)
	{
		gamePresenter = gp;
		gamePresenter.OnChangePonts += SetPoints;
		gamePresenter.OnChangeEnergy += SetEnergy;
	}

	private void SetPoints(int points)
	{
		gameValues.points = points;
	}

	private void SetEnergy(int energy)
	{
		gameValues.energy = energy;
	}
}
