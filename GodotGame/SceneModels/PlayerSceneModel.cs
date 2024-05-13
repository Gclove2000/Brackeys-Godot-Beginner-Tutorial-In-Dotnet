using Godot;
using GodotGame.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodotGame.SceneModels
{
    public class PlayerSceneModel : ISceneModel
    {
        private PrintHelper printHelper;

        private CharacterBody2D characterBody2D;
        private Sprite2D sprite2D;
        private AnimationPlayer animationPlayer;
        private CollisionShape2D collisionShape2D;
        

        public const int SPEED = 300;

        public const int JUMP_VELOCITY = -400;

        public enum AnimationEnum { Idel,Run,Roll,Hit,Death}

        private AnimationEnum animationState = AnimationEnum.Idel;

        public AnimationEnum AnimationState
        {
            get => animationState;
            set
            {
                if(animationState != value)
                {
                    printHelper?.Debug($"[{animationState}] => [{value}]");
                    animationState = value;

                }
            }
        }

        private bool isFlip = false;

        public bool IsFlip
        {
            get => isFlip;
            set
            {

                if(isFlip != value)
                {
                    var postion = characterBody2D.Scale;
                    postion.X = -1;
                    characterBody2D.Scale = postion;
                    isFlip = value;
                }
            }
        }
        public PlayerSceneModel(PrintHelper printHelper)
        {
            this.printHelper = printHelper;
            printHelper.SetTitle(nameof(PlayerSceneModel));
        }
        public override void Ready()
        {
            characterBody2D = Scene.GetNode<CharacterBody2D>("CharacterBody2D");
            sprite2D = Scene.GetNode<Sprite2D>("CharacterBody2D/Sprite2D");
            animationPlayer = Scene.GetNode<AnimationPlayer>("CharacterBody2D/AnimationPlayer");
            collisionShape2D = Scene.GetNode<CollisionShape2D>("CharacterBody2D/CollisionShape2D");

            printHelper.Debug("加载成功！");
        }

       
        public override void Process(double delta)
        {
            Move(delta);
            
            Play();
            SetAnimation();
        }

        private void SetAnimation()
        {
            if (!characterBody2D.IsOnFloor())
            {
                AnimationState = AnimationEnum.Roll;
            }
            switch (AnimationState)
            {
                case AnimationEnum.Idel:
                    if (!Mathf.IsZeroApprox(characterBody2D.Velocity.X))
                    {
                        AnimationState = AnimationEnum.Run;
                    }
                    break;
                case AnimationEnum.Run:
                    if (Mathf.IsZeroApprox(characterBody2D.Velocity.X))
                    {
                        AnimationState = AnimationEnum.Idel;
                    }
                    break;
                case AnimationEnum.Hit:
                    break;
                case AnimationEnum.Death:
                    break;
                case AnimationEnum.Roll:
                    if (characterBody2D.IsOnFloor())
                    {
                        AnimationState = AnimationEnum.Idel;
                    }
                    break;
            }
            if (!characterBody2D.IsOnFloor())
            {
                printHelper.Debug("跳跃");
                AnimationState = AnimationEnum.Roll;
            }
        }

        private void Move(double delta)
        {
            var move = new Vector2(0,0);
            move = characterBody2D.Velocity;
            move.Y += (float)(MyGodotSetting.GRAVITY * delta);
            
            if (MyGodotSetting.IsActionJustPressed(MyGodotSetting.InputMapEnum.Jump) && characterBody2D.IsOnFloor())
            {
                printHelper.Debug("跳跃");
                move.Y = JUMP_VELOCITY;
            }

            var direction = Input.GetAxis(MyGodotSetting.InputMapEnum.Left.ToString(), MyGodotSetting.InputMapEnum.Right.ToString());
            if(Mathf.IsZeroApprox(direction))
            {
                move.X = (float)Mathf.MoveToward(move.X, 0, delta*SPEED);

            }
            else
            {
                move.X = (float)Mathf.MoveToward(move.X, direction*SPEED, delta * SPEED);
                IsFlip = direction < 0;
            }

            characterBody2D.Velocity = move;
            characterBody2D.MoveAndSlide();
        }
        
       

        private void Play()
        {
            animationPlayer.Play(AnimationState.ToString());

        }
    }
}
