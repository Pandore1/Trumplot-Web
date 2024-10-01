using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour
{
    [SerializeField] private GameObject _proofPrefab;
    [SerializeField] private Transform _proofListContainer;
    [SerializeField] private TMPro.TMP_Text _proofName;
    [SerializeField] private TMPro.TMP_Text _proofDesc;
    [SerializeField] private List<GameObject> _proofList;

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
        FoundProof("pot de miel", "blabla");
    }

    public void  FoundProof(string proofName,string proofDesc)
    {
        GameObject _newProof = Instantiate(_proofPrefab, _proofListContainer);
        _proofName.text =proofName;
        _proofDesc.text =proofDesc;
        
    
        _proofList.Add(_newProof);
    }
}
