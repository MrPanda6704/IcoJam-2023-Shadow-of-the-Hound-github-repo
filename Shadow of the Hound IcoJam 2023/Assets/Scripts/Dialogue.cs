using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textComponent;
    public string[] Lines;
    [SerializeField] float _textSpeed;
    private int _index;

    // Start is called before the first frame update
    void Start()
    {
        _textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_textComponent.text == Lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                _textComponent.text = Lines[_index];
            }
        }
        
    }

    public void StartDialogue()
    {
        _index = 0;
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (_index < Lines.Length -1)
        {
            _index++;
            _textComponent.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in Lines[_index].ToCharArray())
        {
            _textComponent.text += c;
            yield return new WaitForSecondsRealtime(_textSpeed);
        }
    }
}
