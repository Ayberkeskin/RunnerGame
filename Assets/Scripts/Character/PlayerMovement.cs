using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private Rigidbody _rb;
   [SerializeField] private float _speed;

   [SerializeField] private Transform _leftTransform;
   [SerializeField] private Transform _midTransform;
   [SerializeField] private Transform _rightTransform;

   private Transform _currentTransform;
   private Vector3 _targetPosition;

   private void Awake()
   {
      gameObject.transform.position = _midTransform.position;
   }

   private void Start()
   {
      _currentTransform = _midTransform;
      _targetPosition = _midTransform.position; 
   }

   private void Update()
   {
      Move();
      transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * _speed);
   }

   private void Move()
   {
      if (Input.GetKeyDown(KeyCode.A))
      {
         if (_currentTransform == _rightTransform)
         {
            _currentTransform = _midTransform;
            _targetPosition = _midTransform.position; 
         }
         else if (_currentTransform == _midTransform)
         {
            _currentTransform = _leftTransform;
            _targetPosition = _leftTransform.position; 
         }
      }
      else if (Input.GetKeyDown(KeyCode.D))
      {
         if (_currentTransform == _leftTransform)
         {
            _currentTransform = _midTransform;
            _targetPosition = _midTransform.position; 
         }
         else if (_currentTransform == _midTransform)
         {
            _currentTransform = _rightTransform;
            _targetPosition = _rightTransform.position; 
         }
      }
   }
}