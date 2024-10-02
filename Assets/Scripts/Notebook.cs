using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    [SerializeField] private GameObject _evidencePrefab;
    [SerializeField] private Transform _evidenceListContainer;
    [SerializeField] private TMPro.TMP_Text _evidenceName;
    [SerializeField] private TMPro.TMP_Text _evidenceDesc;
    [SerializeField] private List<GameObject> _evidenceList;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HoneyPotClick()
    {
        FoundEvidence("pot de miel", "blabla");
    }

    public void  FoundEvidence(string evidenceName,string evidenceDesc)
    {
        GameObject _newEvidence = Instantiate(_evidencePrefab, _evidenceListContainer);
        _evidenceName.text =evidenceName;
        _evidenceDesc.text =evidenceDesc;
        
    
        _evidenceList.Add(_newEvidence);
    }
}
