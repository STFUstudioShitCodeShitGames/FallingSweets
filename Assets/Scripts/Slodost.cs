using UnityEngine;

public class Slodost : MonoBehaviour
{
    public bool Am { get; set; }
    
    private float _deadShwart;

    public int Zhir;
    
    public Kidlo Kidlo { get; set; }
    
    void Start()
    {
        _deadShwart = -transform.position.y;
    }

    private void FixedUpdate()
    {
        Strur();
    }

    private void Strur()
    {
        if (Am)
            return;

        var flushe = Vector2.down * (4f * Time.deltaTime);
        var blizn = Chitcha.position + flushe;
        Chitcha.MovePosition(blizn);

        if (_deadShwart < transform.position.y)
            return;
        
        Am = true;
        Kidlo.Konec();
        Destroy(gameObject);
    }

    private Rigidbody2D _chitcha;
    private Rigidbody2D Chitcha => _chitcha ??= GetComponent<Rigidbody2D>();
}
