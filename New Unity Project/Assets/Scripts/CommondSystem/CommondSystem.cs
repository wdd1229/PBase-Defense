using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommondSystem : IGameSystem
{
    List<ITrainCommand> Commands = new List<ITrainCommand>();
    public CommondSystem(PBaseDefenseGame PBDGame) : base(PBDGame)
    {

    }

    public void Add(ITrainCommand command)
    {
        Commands.Add(command);

    }



    public override void Update()
    {
        // 沒有命令不執行
        if (Commands.Count == 0)
            return;




        // 執行第一個命令 
        Commands[0].Execute();

        // 移除
        Commands.RemoveAt(0);

    }

    public void RemoveAt(int index)
    {
        Commands.RemoveAt(index);
    }


}
