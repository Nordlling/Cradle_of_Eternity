using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    private SpriteRenderer _renderer;
    public Color AddColorWithEnter;
    private Color _currentAddedColor;
    private Color _clearColor = new Color(1, 1, 1, 1);
    private bool _isClear;
    public float Health = 100;
    public GameObject TreeDropedElement;
    public Sprite Destroyed;

    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _currentAddedColor = _clearColor;
    }

    private void FixedUpdate()
    {
        if (_isClear)
        {
            _currentAddedColor = Color.Lerp(_currentAddedColor, _clearColor, Time.deltaTime);
        } 
        //else _currentAddedColor = Color.Lerp(_currentAddedColor, AddColorWithEnter, Time.deltaTime);
        _renderer.color = _currentAddedColor;
        //_renderer.color = _currentAddedColor + new Color((Health / 100) - Health, 0, 0);
    }

    public void OnEnter()
    {
        _currentAddedColor = AddColorWithEnter;
        _isClear = false;
    }

    public void OnClick()
    {
        Health -= 25;
        if (Health <= 0)
        {
            int count = Random.Range(3, 5);
            var p = transform.position;
            Debug.Log(p);
            for (int i = 0; i < count; i++)
            {
                var go = Instantiate(TreeDropedElement, new Vector3(p.x, p.y + i, p.z), Quaternion.identity);
                go.GetComponent<DroppedItem>().Explode();
            }
            _renderer.sprite = Destroyed;
            _renderer.color = _clearColor;
            var collider = GetComponent<Collider2D>();
            p.y = collider.bounds.min.y;
            transform.position = p;

            Destroy(collider);
            Destroy(this);
        }
    }

    public void OnExit()
    {
        _isClear = true;
    }
}
