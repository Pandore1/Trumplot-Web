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


    public void  FoundProof(string proofName, string proofDesc)
    {
        GameObject _newProof = Instantiate(_proofPrefab, _proofListContainer);

        Transform _newProofName = _newProof.gameObject.transform.Find("ProofName");
        
        Transform _newProofDesc = _newProof.gameObject.transform.Find("ProofDesc");
        _newProofName.gameObject.GetComponent<TMPro.TMP_Text>().text = proofName;
        _newProofDesc.gameObject.GetComponent<TMPro.TMP_Text>().text=proofDesc;
    
        _proofList.Add(_newProof);
    }
}
