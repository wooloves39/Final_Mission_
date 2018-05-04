using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dialog : MonoBehaviour
{
	// Use this for initialization
	public Text _textComponent;

	private string[] DialogueStrings;
	public int[] chatChar;
	private float SecondsBetweenCharacters = 0.1f;
	private float CharacterRateMultuplier = 0.001f;

	private bool _isStringBeingRevealed = false;
	private bool _isEndofDialogue = false;

	public GameObject ContinueIcon;
	public GameObject StopIcon;

	public GameObject Me;
	public GameObject Boss;
	private Dia_Play dia_Play;
	private PlayerState myState;
	private File_parser file_parser;
	public string fileName;

	public GameObject[] WaveStart;
	private int wavecnt = 0;
	void Start()
	{
		dia_Play = GetComponent<Dia_Play>();
		myState = transform.parent.GetComponent<PlayerState>();
		file_parser = new File_parser();
		file_parser.FileOpen(fileName);
		file_parser.Parse();
		DialogueStrings = file_parser.GetText();
		chatChar = file_parser.GetTextChar();
		_textComponent.text = "";
		moveSetting();
		HideIcons();

		StartCoroutine(StartDialogue());
		file_parser.FileClose();
	}
	private IEnumerator StartDialogue()
	{
		yield return new WaitWhile(() => dia_Play.getPlay());
		int dialogueLengh = DialogueStrings.Length;
		int currentDialogueIndex = 0;
		while (currentDialogueIndex < dialogueLengh || !_isStringBeingRevealed)
		{
			if (!_isStringBeingRevealed)
			{
				_isStringBeingRevealed = true;
				moveImage(currentDialogueIndex);
				StartCoroutine(DisplatStrings(DialogueStrings[currentDialogueIndex++]));

				if (currentDialogueIndex >= dialogueLengh || chatChar[currentDialogueIndex] == 99)
				{
					_isEndofDialogue = true;
					if (currentDialogueIndex >= dialogueLengh) ;

					else
					{
						if (chatChar.Length > currentDialogueIndex)
						{
							if (chatChar[currentDialogueIndex] == 99)
							{
								currentDialogueIndex++;
							}
						}
					}


				}
			}
			yield return new WaitWhile(() => dia_Play.getPlay());
		}

		HideIcons();

	}
	private IEnumerator DisplatStrings(string stringToDisplay)
	{
		int stringLength = stringToDisplay.Length;
		int currentCaracterIndex = 0;
		HideIcons();
		_textComponent.text = "";
		while (currentCaracterIndex < stringLength)
		{
			_textComponent.text += stringToDisplay[currentCaracterIndex];
			currentCaracterIndex++;
			if (currentCaracterIndex < stringLength)
			{
				if (InputManager_JHW.BButton())
				{
					yield return new WaitForSeconds(CharacterRateMultuplier);
				}
				else
				{
					yield return new WaitForSeconds(SecondsBetweenCharacters);
				}
			}
			else break;
		}
		ShowIcon();
		while (true)
		{
			if (InputManager_JHW.BButtonDown())
			{
				if (_isEndofDialogue)
				{
					dia_Play.setEnd(true);
					if (WaveStart.Length > 0)
					{
						myState.SetMyState(PlayerState.State.Nomal);
						dia_Play.setPlay(true);
						if (WaveStart[wavecnt] != null)
						{
							Debug.Log(WaveStart[wavecnt]);
							WaveStart[wavecnt].GetComponent<MobGenerater>().Wave_Start = true;
							wavecnt++;
						}
						else
						{
							Debug.Log(WaveStart[wavecnt]);
						}
					}
				}
				break;
			}
			yield return 0;
		}
		HideIcons();
		_isStringBeingRevealed = false;
		_textComponent.text = "";
		if (_isEndofDialogue)
		{
			_isEndofDialogue = false;
			dia_Play.setPlay(true);
		}
	}
	private void HideIcons()
	{
		ContinueIcon.SetActive(false);
		StopIcon.SetActive(false);

	}
	private void ShowIcon()
	{
		if (_isEndofDialogue)
		{
			StopIcon.SetActive(true);
			return;
		}
		ContinueIcon.SetActive(true);
	}
	private void moveSetting()
	{
		//iTween.MoveFrom(Me, iTween.Hash("x", Me.transform.position.x - 2.0f, "time", 1.0f, "easetype", iTween.EaseType.easeOutBounce));
		//iTween.MoveFrom(Boss, iTween.Hash("x", Boss.transform.position.x + 2.0f, "time", 1.0f, "easetype", iTween.EaseType.easeOutBounce));
	}
	private void moveImage(int currentDialogueIndex)
	{
		if (currentDialogueIndex == 0) return;
		if (chatChar[currentDialogueIndex] == 0)
			iTween.ShakePosition(Me, iTween.Hash("amount", new Vector3(0.2f, 0.1f, 0.1f), "time", 1.0f));
		else if (chatChar[currentDialogueIndex] == 1)
		{
			iTween.ShakePosition(Boss, iTween.Hash("amount", new Vector3(0.2f, 0.1f, 0.1f), "time", 1.0f));

		}
	}

}
