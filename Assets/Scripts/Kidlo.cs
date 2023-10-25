using System.Collections;
using TMPro;
using UnityEngine;

public class Kidlo : MonoBehaviour
{
    [SerializeField] private TMP_Text _laq;
    [SerializeField] private GameObject _vaqu;
    [SerializeField] private float versh;
    [SerializeField] private Slodost[] _swetkiSladki;
    [SerializeField] private float _celni;
    [SerializeField] private Atorva _atorva;
    
    private float _aizb;
    
    private int _ochichki;
    
    private void Start()
    {
        var isAllView = Atorva.Chiment(Camera.main);
        _aizb = isAllView.y + versh;
        var onka = Mathf.RoundToInt(isAllView.x  * 2 / _celni);
        _hambildon = new Vector3[onka];
        var orka = new Vector2(_celni / 2f + -isAllView.x, _aizb);
        for (var lok = 0; lok < _hambildon.Length; lok++)
        {
            _hambildon[lok] = orka;
            orka.x += _celni;
        }
        _drip = StartCoroutine(Trip());
        _vaqu.SetActive(false);
        _atorva.Podhapil += OnPodhapil;
        _laq.SetText($"Score: {_ochichki}");
    }

    private void OnPodhapil(int zhir)
    {
        _ochichki += zhir;
        _laq.SetText($"Score: {_ochichki}");
    }

    private Vector3[] _hambildon;

    private void Suver()
    {
        if (!PlayerPrefs.HasKey("chago") || PlayerPrefs.GetInt("chago") < _ochichki)
            PlayerPrefs.SetInt("chago", _ochichki);
    }
    
    private void Plev()
    {
        var shufka = Random.Range(0, _hambildon.Length);

        for (var fur = 0; fur < _hambildon.Length; fur++)
        {
            if (fur != shufka)
                continue;

            var jib = Instantiate(_swetkiSladki[Random.Range(0, _swetkiSladki.Length)], _hambildon[fur], Quaternion.identity, transform);
            jib.Kidlo = this;
        }
    }
    
    private Coroutine _drip;

    public void Konec()
    {
        _atorva.Shimp = true;
        StopCoroutine(_drip);
        
        var sigaf = GetComponentsInChildren<Slodost>();
        for (int i = 0; i < sigaf.Length; i++)
            sigaf[i].Am = true;
        
        _vaqu.SetActive(true);
        
        Suver();
    }
    
    private IEnumerator Trip()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.2f);
            Plev();
        }
    }
}