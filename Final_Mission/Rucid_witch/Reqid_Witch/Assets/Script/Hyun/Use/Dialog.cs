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
	public string fileName;

	public GameObject[] WaveStart;
	public NextStage next;
	public GameObject nextParticle;
	private int wavecnt = 0;
	Vector3 MeCurPos;
	Vector3 BossCurPos;

	void Start()
	{
		File_parser file_parser = new File_parser(); 
		dia_Play = GetComponent<Dia_Play>();
		myState = transform.parent.GetComponent<PlayerState>();
		file_parser.FileOpen(fileName);
		file_parser.Parse();
		DialogueStrings = file_parser.GetText();
		chatChar = file_parser.GetTextChar();
		_textComponent.text = "";
		HideIcons();

		StartCoroutine(StartDialogue());
		file_parser.FileClose();
	}
	private IEnumerator StartDialogue()//전체 다이얼로그 돌리기
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
		if (next)
		{
			next.gameObject.SetActive(true);
			next.setNextOn(true);
		}
		if (nextParticle)
			nextParticle.SetActive(true);
		HideIcons();

	}
	private IEnumerator DisplatStrings(string stringToDisplay)//다이얼로그 한줄씩 돌리기
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
				if (InputManager_JHW.AButton()||Input.GetKey(KeyCode.S))
				{
					for(int i = currentCaracterIndex; i < stringLength; ++i)
					{
						_textComponent.text += stringToDisplay[i];
					}
					break;
				}
			}
			else break;
		}
		ShowIcon();
		while (true)
		{
			if (InputManager_JHW.BButtonDown()|| InputManager_JHW.AButton()|| Input.GetKey(KeyCode.S))
			{
				if (_isEndofDialogue)
				{
					dia_Play.setEnd(true);
					if (WaveStart.Length > 0)
					{
						myState.SetMyState(PlayerState.State.Nomal);
						dia_Play.setPlay(true);
						if (wavecnt < WaveStart.Length)
						{
							WaveStart[wavecnt].GetComponent<MobGenerater>().waveOn();
							wavecnt++;
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
			 Me.transform.localPosition= MeCurPos;
		 Boss.transform.localPosition = BossCurPos;
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
	private void moveImage(int currentDialogueIndex)
	{
		MeCurPos=Me.transform.localPosition;
		BossCurPos = Boss.transform.localPosition;
		if (currentDialogueIndex == 0) return;
		if (chatChar[currentDialogueIndex] == 0)
			iTween.ShakePosition(Me, iTween.Hash("amount", new Vector3(0.05f, 0.05f, 0.05f), "time", 0.1f));
		else if (chatChar[currentDialogueIndex] == 1)
		{
			iTween.ShakePosition(Boss, iTween.Hash("amount", new Vector3(0.05f, 0.05f, 0.05f), "time", 0.1f));
		}
	}
}
