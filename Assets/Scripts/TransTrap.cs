using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransTrap : MonoBehaviour
{
    public void IncripTgr(int shih) => SceneManager.LoadScene(shih);

    public void Zakonchil() => Application.Quit();
    
    [SerializeField] private TMP_Text _ceTextik;

    private void Awake()
    {
        if (_ceTextik == null)
            return;
        
        var shchit = PlayerPrefs.HasKey("chago") 
            ? PlayerPrefs.GetInt("chago") : 0;
        _ceTextik.SetText($"Besct score: {shchit}");
        
        Application.targetFrameRate = 120;
    }
}
