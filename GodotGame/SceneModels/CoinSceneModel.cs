using Godot;
using GodotGame.SceneScripts;
using GodotGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodotGame.SceneModels
{
    public class CoinSceneModel : ISceneModel
    {
        private PrintHelper printHelper;

        private Area2D area2D;

        private Sprite2D sprite2D;
        private AnimationPlayer animationPlayer;
        private CollisionShape2D collisionShape2D;

        public CoinSceneModel(PrintHelper printHelper) {
            this.printHelper = printHelper;
            this.printHelper.SetTitle(nameof(CoinSceneModel));
        }
        public override void Process(double delta)
        {
        }

        public override void Ready()
        {
            area2D = Scene.GetNode<Area2D>("Area2D");
            sprite2D = Scene.GetNode<Sprite2D>("Area2D/Sprite2D");
            animationPlayer = Scene.GetNode<AnimationPlayer>("Area2D/AnimationPlayer");
            collisionShape2D = Scene.GetNode<CollisionShape2D>("Area2D/CollisionShape2D");
            printHelper.Debug("加载完成");
            area2D.BodyEntered += Area2D_BodyEntered;
        }

        private void Area2D_BodyEntered(Node2D body)
        {
            printHelper.Debug("有东西进入");

            if (body is PlayerScene)
            {
                printHelper.Debug("玩家进入");
            }
            if(body.GetParent() is PlayerScene)
            {
                printHelper.Debug("父节点是玩家的进入");

            }
            Scene.QueueFree();
        }
    }
}
