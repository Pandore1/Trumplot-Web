using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Examination : MonoBehaviour
{
    // Start is called before the first frame update
    private string _examinationLines;
    [SerializeField] private TMPro.TMP_Text _examinationComponent;
    [SerializeField] private GameObject _examinationPanel;
    [SerializeField] private float _examinationSpeed = 0.5f;
    [SerializeField] private GameObject _accusationPanel;

    [SerializeField] private string[] _guilty = new string[2];

    [SerializeField] private TMPro.TMP_Text _accusationText;
    [SerializeField] private TMPro.TMP_Text _winLoseText;
    [SerializeField] private GameObject _restartBtn;

    private string _speakSuspect;
    private string _judgeSuspect;
    private string _accused1;
    private string _accused2;
 

    [SerializeField] List<SuspectInfos> infos;


    void Start()
    {
        _examinationComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Lineup(string suspect)
    {
        if (_speakSuspect == null)
        {
            _speakSuspect = suspect;
        }
        else if(_speakSuspect!=null)
        {
            _judgeSuspect = suspect;
           
            StartDialogue();
        }
    }
    public void StartDialogue()

    {
        Debug.Log(_speakSuspect + "" + _judgeSuspect);


        SuspectInfos newInfos = infos.Find(suspect => suspect.SpeakingSupectName == _speakSuspect);
        SuspectJudgement newJudgement = newInfos.OtherSuspects.Find(judgementSuspect => judgementSuspect.JudgedSupectName == _judgeSuspect);
        SuspectJudgement newEvidenceSuspect = newInfos.OtherSuspects.Find(judgementSuspect => judgementSuspect.Evidence);
        if (newEvidenceSuspect != null && newEvidenceSuspect.Evidence)
        {
            ApplicationManager.Instance._noteBookScript.FoundEvidence((_speakSuspect + " - " + _judgeSuspect), newJudgement.Judgement);
        }
        _examinationLines = newJudgement.Judgement;
      
        _examinationPanel.SetActive(true);
  

        StartCoroutine(TypeDialogue());

    }
    IEnumerator TypeDialogue()
    {
       
        foreach (char c in _examinationLines.ToCharArray())
        {
            _examinationComponent.text += c;
            yield return new WaitForSeconds(_examinationSpeed);
        }


        Invoke("CleanDialogue", 2f);


    }

    private void CleanDialogue()
    {
        _speakSuspect = null;
        _judgeSuspect = null;
        _examinationComponent.text = string.Empty;
        _examinationPanel.SetActive(false);
    }
    public void AccuseBtn()
    {   
        _accusationPanel.SetActive(true);
    }
    public void Accusation(string accused)
    {
        if (_accused1 == null)
        {
            _accused1 = accused;
            _accusationText.text = _accused1;
        }
        else
        {
            _accused2= accused;
            _accusationText.text = _accused1 + " - " + _accused2;
        }
        
    }
    public void VerifyAccusation()
    {
        if (_accused1 != null && _accused2 != null)
        {
            if ((_accused1 == _guilty[0] || _accused1 == _guilty[1])&&(_accused2 == _guilty[0] || _accused2 == _guilty[1])&&_accused1!=_accused2)
            {
                _winLoseText.text = "Bravo M. Trump vous avez trouvé les reptiliens de Washington avant les élections";

                Invoke("Win", 3f);
            }
            else
            {
                _winLoseText.text = "Vous avez accusez des innocents et les reptiliens ont gagnés, allez en prison.";
            }
            _restartBtn.SetActive(true);    
        }

    }
    private void Win()
    {
        ApplicationManager.Instance.SwitchScene("Win");
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
 
