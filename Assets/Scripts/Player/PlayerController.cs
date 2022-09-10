using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PAG
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Input Provider")]
        [SerializeField] private InputProvider _inputProvider;

        [Header("Test")]
        [SerializeField] Rigidbody2D rb2D;
        [SerializeField] float speed = 100;
        [SerializeField] float jumpForce = 50;
        
        private void Awake()
        {
            _inputProvider.SetupHandlers();
            _inputProvider.ToggleHandler(0, true);
        }

        private void OnEnable()
        {
            _inputProvider.onGenericAction += Jump;
        }

        private void OnDisable()
        {
            _inputProvider.onGenericAction -= Jump;
        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {
            rb2D.AddForce(_inputProvider.GetState().movementDirection * Time.fixedDeltaTime * speed);
        }

        private void Jump()
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
