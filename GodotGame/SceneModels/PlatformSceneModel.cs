using GodotGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodotGame.SceneModels
{
    public class PlatformSceneModel : ISceneModel
    {

        private PrintHelper printHelper;

        public PlatformSceneModel(PrintHelper printHelper)
        {
            this.printHelper = printHelper;
            printHelper.SetTitle(nameof(PlatformSceneModel));   
        }

        public override void Process(double delta)
        {
        }

        public override void Ready()
        {
            printHelper.Debug("加载成功！");
        }
    }
}
