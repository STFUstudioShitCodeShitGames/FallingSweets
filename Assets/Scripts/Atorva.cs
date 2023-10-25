using System;
using UnityEngine;

public class Atorva : MonoBehaviour
{
    public event Action<int> Podhapil; 

    [SerializeField] private float _upcent;
    [SerializeField] private float _stoper;

    private float _stopka;
    
    public bool Shimp { get; set; }
    
    public static Vector2 Shork { get; set; }
    
    private void Start()
    {
        Shork = Chiment(Camera.main);
        _stopka = Shork.x - _upcent;

        transform.position = new Vector3(0, -Shork.y);
    }
    
    private void Update()
    {
        if (!Input.GetMouseButton(0) || Shimp)
            return;
        
        var wPo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var fihtv = transform.position;
        wPo.y = fihtv.y;
        wPo.z = 0;
        wPo.x = Mathf.Clamp(wPo.x, -_stopka, _stopka);
        
        fihtv = Vector3.Lerp(fihtv, wPo, _stoper * Time.deltaTime);
        transform.position = fihtv;
    }

    public static Vector2 Chiment(Camera heramera)
    {
        var pulka = new Vector3(heramera.pixelWidth, heramera.pixelHeight);
        return heramera.ScreenToWorldPoint(pulka);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var sladko = other.GetComponent<Slodost>();
        if (sladko == null)
            return;
        
        Podhapil?.Invoke(sladko.Zhir);
        Destroy(sladko.gameObject);
    }
}
