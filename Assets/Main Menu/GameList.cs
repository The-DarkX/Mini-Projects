using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class GameList : MonoBehaviour
{
	[Serializable]
	public class Game
	{
		public string title;
		public string author;
		public Sprite icon;

		public int sceneIndex;
	}

	[SerializeField] GameObject buttonTemplate;
	[SerializeField] Transform displayPanel;
	[SerializeField] Game[] allGames;

	void Start()
	{
		for (int i = 0; i < allGames.Length; i++)
		{
			GameObject game = Instantiate(buttonTemplate, displayPanel);
			game.transform.GetChild(0).GetComponent<Image>().sprite = allGames[i].icon;
			game.transform.GetChild(1).GetComponent<TMP_Text>().text = allGames[i].title;
			game.transform.GetChild(2).GetComponent<TMP_Text>().text = allGames[i].author;

			game.GetComponent <Button> ().onClick.AddListener (delegate() {
				ItemClicked (i);
			});
		}
	}

	void ItemClicked(int itemIndex)
	{
		GameManager.LoadScene(allGames[itemIndex - 1].sceneIndex);
	}
}