using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public Rigidbody RigidBody => _rigidbody;
}
