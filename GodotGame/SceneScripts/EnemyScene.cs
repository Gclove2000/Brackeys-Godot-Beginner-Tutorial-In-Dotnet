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
    public partial class EnemyScene :Node2D
    {
        public EnemySceneModel Model { get; set; }

        public EnemyScene()
        {
            Model = Program.Services.GetService<EnemySceneModel>();
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
