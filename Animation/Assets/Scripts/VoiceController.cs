using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceController : MonoBehaviour
{
    public KeywordRecognizer keywordRecognizer;
    public Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
    public GameObject toMove;

    // Start is called before the first frame update
    void Start()
    {
        keywords.Add("Move", MoveObject);
        keywords.Add("Colour", ChangeColour);

        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognisedSpeech;
        keywordRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RecognisedSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        keywords[speech.text].Invoke();
    }

    void MoveObject()
    {
        toMove.transform.position += new Vector3(90,0,0) * Time.deltaTime;
    }

    void ChangeColour()
    {
        var rend = toMove.GetComponent<Renderer>();
        rend.material.SetColor("_Color", Color.red);
    }
}
