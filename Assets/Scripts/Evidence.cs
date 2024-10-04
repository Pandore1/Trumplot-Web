using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evidence : MonoBehaviour
{
    // Start is called before the first frame update
    public void BeetleJar()
    {
        ApplicationManager.Instance._noteBookScript.FoundEvidence("Kristine","Elle avait un jarre remplis d'insecte aromatisé dans son frigo");

    }
    public void Poster()
    {
        ApplicationManager.Instance._noteBookScript.FoundEvidence("Kay", "Affiche avec visage reptilien de domination caché derrière une autre affiche");

    }
}
