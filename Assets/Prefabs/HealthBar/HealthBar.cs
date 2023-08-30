using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    #region Champs
    [SerializeField] Image _bar;
    [SerializeField] float _barMax = 0.5f;
    [SerializeField] float _barValues;

    public float BarMax { get => _barMax; }
    public float BarValue { get => _barValues; set => _barValues = value; }
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region Methods
    void FixedUpdate ()
    {
        
    }
    void LateUpdate ()
    {
        
    }
    #endregion
    #region Coroutines
    #endregion
}
