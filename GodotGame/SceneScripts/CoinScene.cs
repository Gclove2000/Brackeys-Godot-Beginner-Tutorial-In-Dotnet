using Godot;
using GodotGame.SceneModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodotGame.SceneScripts
{
    public partial class CoinScene :Node2D
    {
        public CoinSceneModel Model { get; set; }
        public CoinScene() {
            Model = Program.Services.GetService<CoinSceneModel>();
            Model.Scene = this;
        }

        public override void _Ready()
        {
            base._Ready();
            Model.Ready();
        }

        public override void _Process(double delta)
        {
            base._Process(delta);
            Model.Process(delta);

        }
    }
}
