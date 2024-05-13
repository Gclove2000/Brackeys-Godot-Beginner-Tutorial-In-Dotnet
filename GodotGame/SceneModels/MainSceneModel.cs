using GodotGame.DB;
using GodotGame.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodotGame.SceneModels
{
    public class MainSceneModel : ISceneModel
    {
        private PrintHelper printHelper;

        private FreeSqlHelper freeSqlHelper;

        public MainSceneModel(PrintHelper printHelper, FreeSqlHelper freeSqlHelper)
        {
            this.printHelper = printHelper;
            this.freeSqlHelper = freeSqlHelper;
        }

        public override void Process(double delta)
        {

        }

        public override void Ready()
        {
            printHelper.Info("主函数加载成功！");
            
        }
    }
}
