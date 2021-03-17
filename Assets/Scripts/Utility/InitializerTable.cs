using UnityEngine;

namespace Utility
{
    [CreateAssetMenu( menuName = "ScriptableObject/Create InitializerTable", fileName = "InitializerTable" )]
    public class InitializerTable : ScriptableObject
    {
        [field: SerializeField] public GameObject[] Objects { get; private set; }
    } // class ParameterTable
}