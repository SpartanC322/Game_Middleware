using System.Collections;
using System.Collections.Generic;
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
        keywords.Add("activate", () => { MoveObject(); }); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveObject()
    {
        toMove.transform.position += new Vector3(90,0,0) * Time.deltaTime;
    }
}
