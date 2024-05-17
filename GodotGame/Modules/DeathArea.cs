using Godot;
using GodotGame.SceneScripts;
using GodotGame.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodotGame.Modules
{
    [GlobalClass]
    public partial class DeathArea :Area2D
    {
        private PrintHelper printHelper;
        public DeathArea() {

            this.printHelper = Program.Services.GetService<PrintHelper>();
            this.printHelper.SetTitle(nameof(DeathArea));
            this.BodyEntered += DeathArea_BodyEntered;
        }

        private void DeathArea_BodyEntered(Node2D body)
        {
            printHelper.Debug("Anythiny enter!");
            //如果玩家进入，则等待0.6秒后重新加载
            if (body.GetParent() is PlayerScene)
            {
                printHelper.Debug("You Get Die");
                var scene = (PlayerScene) body.GetParent();
                Reload(scene);

            }
        }

        /// <summary>
        /// 为了线程安全，我们只能这么做
        /// </summary>
        /// <returns></returns>
        private async Task Reload(PlayerScene scene)
        {
            await Task.Delay(600);
            scene.Model.Reload();
            GetTree().ReloadCurrentScene();

        }
    }
}
