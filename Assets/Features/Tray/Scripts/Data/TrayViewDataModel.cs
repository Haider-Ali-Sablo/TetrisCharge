using System.Collections.Generic;
using Sablo.UI;
using UnityEngine;

namespace Sablo.Gameplay.Shape
{
    public class TrayViewDataModel: BaseViewDataModel
    {
        public ITray TrayHandler;
        public List<BaseShape> ShapeTypes;
    }
}