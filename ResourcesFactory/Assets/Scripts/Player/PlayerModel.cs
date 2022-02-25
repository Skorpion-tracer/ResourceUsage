using UnityEngine;

[CreateAssetMenu(fileName = nameof(PlayerModel),
menuName = "Game/" + nameof(PlayerModel), order = 0)]
public class PlayerModel : ScriptableObject
{
    [SerializeField] private float _speed;

    public float Speed => _speed;
}
