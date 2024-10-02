using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Examination : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private string _examinationLines;

    /*
     0: Kevin
     1: Karim
     2: Kay
     3: Karen
     4:Kristine
     */
    [SerializeField] private TMPro.TMP_Text _examinationComponent;
    [SerializeField] private GameObject _examinationCanva;
    [SerializeField] private float _examinationSpeed = 0.5f;
    private string _speakSuspect;
    private string _judgeSuspect;

    [SerializeField] List<SuspectInfos> infos;
    private int _index;

    void Start()
    {
        _examinationComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& EventSystem.current.currentSelectedGameObject.tag=="SuspectLineup")
        {
            if (_speakSuspect == null)
            {
                _speakSuspect = EventSystem.current.currentSelectedGameObject.name;
            }
            else
            {
                _judgeSuspect = EventSystem.current.currentSelectedGameObject.name;
                StartDialogue();
            }
           
        }
     
    }
    public void StartDialogue()

    {
        SuspectInfos newInfos = infos.Find(suspect => suspect.SpeakingSupectName == _speakSuspect);
        SuspectJudgement newJudgement = newInfos.OtherSuspects.Find(judgementSuspect => judgementSuspect.JudgedSupectName == _judgeSuspect);
        SuspectJudgement newEvidenceSuspect = newInfos.OtherSuspects.Find(judgementSuspect => judgementSuspect.Evidence);
        if (newEvidenceSuspect != null && newEvidenceSuspect.Evidence)
        {
            GameManager.Instance._noteBookScript.FoundEvidence((_speakSuspect + " - " + _judgeSuspect), newJudgement.Judgement);
        }
        _examinationLines = newJudgement.Judgement;
        _index = 0;
        _examinationCanva.SetActive(true);
       
        StartCoroutine(TypeDialogue());

    }
    IEnumerator TypeDialogue()
    {
        foreach (char c in _examinationLines.ToCharArray())
        {
            _examinationComponent.text += c;
            yield return new WaitForSeconds(_examinationSpeed);
        }
        _speakSuspect = string.Empty;
        _judgeSuspect = string.Empty;


    }
    [Serializable]
    public class SuspectInfos
    {

        public string SpeakingSupectName;
        public List<SuspectJudgement> OtherSuspects;

    }
    [Serializable]
    public class SuspectJudgement
    {

        public string JudgedSupectName;
        public bool Evidence;
        [TextArea]
        public string Judgement;


    }
}
 
