using System;
using UnityEngine;

[CreateAssetMenu(menuName ="Item")]
class AssetItem :ScriptableObject, IItem
{
    public string Name => throw new NotImplementedException();

    public Texture2D UIIcon => throw new NotImplementedException();
    [SerializeField] private  string _name;
    [SerializeField]private Texture2D _uiIcon;
}

