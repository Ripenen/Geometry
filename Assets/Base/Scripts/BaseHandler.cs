using System;
using ExtensionsApi;

namespace Base.Scripts
{
    public sealed class BaseHandler : Handler
    {
        public event Action<int> CubeMoved;
        private readonly Player _player;

        public BaseHandler(Player player)
        {
            _player = player;
        }
        public override void Handle(Cube cube)
        {
            SelectedElement = cube;
        }

        public override void Handle(Circle circle)
        {
            if (!(SelectedElement is Cube cube)) 
                return;
        
            if(circle.Size < cube.Size || cube.IsMoved || circle.IsBusy)
                return;
        
            cube.MoveTo(circle.transform.position);
            circle.MakeBusy();
            _player.Moves++;
            CubeMoved?.Invoke(_player.Moves);
            SelectedElement = null;
        }
    }
}