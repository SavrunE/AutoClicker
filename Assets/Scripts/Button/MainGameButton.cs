using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MainGameButton : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI text;
	[SerializeField] private GameView gameView;
	private Button button;
    private const int tmpImagesCount = 16;

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonClicked);
        button.onClick.AddListener(gameView.MainButtonClicked);
	}

    private void ButtonClicked()
    {
        TakeRndImage();
	}

    private void TakeRndImage()
    {
        var rnd = Random.Range(0, tmpImagesCount);
        text.text = $"<sprite={rnd}> ";
	}
}
