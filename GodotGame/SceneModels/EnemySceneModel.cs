using GodotGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodotGame.SceneModels
{
    public class EnemySceneModel : ISceneModel
    {
        private PrintHelper printHelper;
        public EnemySceneModel(PrintHelper printHelper)
        {
            this.printHelper = printHelper;
            this.printHelper.SetTitle(nameof(EnemySceneModel));
        }
        public override void Process(double delta)
        {

        }

        public override void Ready()
        {
            printHelper.Debug("加载完成");
        }
    }
}
