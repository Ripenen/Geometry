using System;
using Base.Scripts;
using ExtensionsApi;
using UnityEngine;

namespace Extensions.Triangle
{
    public sealed class TriangleHandler : ExtensionHandler, IElementHandler<Triangle>
    {
        public event Action<int> EnergyChanged;
    
        private readonly TrianglePlayer _player;
    
        public TriangleHandler(Handler handler, TrianglePlayer player) : base(handler)
        {
            _player = player;
        }
    
        public void Handle(Triangle triangle)
        {
            SelectedElement = triangle;
        }
        public override void Handle(Cube cube)
        {
            if (SelectedElement is Triangle triangle && _player.Energy > 0)
            {
                cube.DecreaseSize();
                triangle.Destroy();
                _player.DecreaseEnergy();
                EnergyChanged?.Invoke(_player.Energy);
                SelectedElement = null;
            }
        
            base.Handle(cube);
        }
    }
}