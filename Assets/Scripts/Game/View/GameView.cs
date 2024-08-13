using TMPro;
using UnityEngine;

public class GameView : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI points;
	[SerializeField] private TextMeshProUGUI energy;
	[SerializeField] private ClickEffect clickEffect;
	[SerializeField] private Transform clickEffectParrent;
	GamePresenter gamePresenter;
	public void Init(GamePresenter gp)
	{
		gamePresenter = gp;
		gamePresenter.OnChangePonts += UpdatePoints;
		gamePresenter.OnChangeEnergy += UpdateEnergy;
	}

	public void MainButtonClicked()
	{
		int pointCounts = gamePresenter.OnMainButtonClicked();
		ClickEffect effect = Instantiate(clickEffect.gameObject, clickEffectParrent).GetComponent<ClickEffect>();
		effect.Init(pointCounts.ToString());
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
