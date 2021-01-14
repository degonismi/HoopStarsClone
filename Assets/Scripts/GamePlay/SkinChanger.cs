using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HoopStar
{
    //"ленивая" смена скина (материала) просто чтобы было)
    public class SkinChanger : MonoBehaviour
    {
        [SerializeField] private List<Material> _materials;
        [SerializeField] private Renderer _renderer;
        
        private void OnEnable()
        {
            _renderer.material = _materials[Random.Range(0, _materials.Count)];
        }
    }
}