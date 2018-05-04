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
    public float SecondsBetweenCharacters = 0.15f;
    public float CharacterRateMultuplier = 0.5f;

    public KeyCode DialogueInput = KeyCode.Return;
    private bool _isStringBeingRevealed = false;
    private bool _isEndofDialogue = false;

    public GameObject ContinueIcon;
    public GameObject StopIcon;

    public GameObject Me;
    public GameObject Boss;
	public Dia_Play dia_Play;
	private File_parser file_parser;
	public string fileName;
	void Start()
    {
		file_parser = new File_parser();
		file_parser.FileOpen(fileName);
		file_parser.Parse();
		DialogueStrings = file_parser.GetText();
		chatChar = file_parser.GetTextChar();
        _textComponent.text = "";
        moveSetting();
        HideIcons();
		
		StartCoroutine(StartDialogue());
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    if (!_isStringBeingRevealed)
        //    {
        //        _isDialoguePlaying = true;
        //        StartCoroutine(StartDialogue());
        //    }
        //}
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
					if (chatChar[currentDialogueIndex] == 99) currentDialogueIndex++;
					_isEndofDialogue = true;
				}
            }
            yield return new WaitWhile(()=>dia_Play.getPlay());
        }
  //      while (true)
  //      {
  //          if (Input.GetKeyDown(DialogueInput)) break;
			
		//}
        HideIcons();
        _isEndofDialogue = false;
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
                if (Input.GetKey(DialogueInput))
                {
					yield return new WaitForSeconds(SecondsBetweenCharacters * CharacterRateMultuplier);
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
            if (Input.GetKeyDown(DialogueInput)) break;
            yield return 0;
        }
        HideIcons();
        _isStringBeingRevealed = false;
        _textComponent.text = "";
		if (_isEndofDialogue) {
			_isEndofDialogue = false;
			dia_Play.setPlay(true); }

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
        if (chatChar[currentDialogueIndex]==0) 
        iTween.ShakePosition(Me, iTween.Hash("amount",new Vector3( 0.2f,0.1f,0.1f), "time", 1.0f));
        else if(chatChar[currentDialogueIndex] == 1)
        {
            iTween.ShakePosition(Boss, iTween.Hash("amount", new Vector3(0.2f, 0.1f, 0.1f), "time", 1.0f));

        }
    }
	
}
