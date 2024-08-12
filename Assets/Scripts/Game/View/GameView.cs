using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI points;
	[SerializeField] private TextMeshProUGUI energy;
	GamePresenter gamePresenter;
	public void Init(GamePresenter gp)
	{
		gamePresenter = gp;
		gamePresenter.OnChangePonts += UpdatePoints;
		gamePresenter.OnChangeEnergy += UpdateEnergy;
	}

	public void MainButtonClicked()
    {
        gamePresenter.OnMainButtonClicked();
	}

	public void UpdatePoints(int pointsCount)
	{
		points.text = pointsCount.ToString();
	}

	public void UpdateEnergy(int energyCount)
	{
		energy.text = energyCount.ToString();
	}
}
