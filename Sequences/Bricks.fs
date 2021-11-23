namespace Sequences

open System

type Brick =
    {
        StudColumns : int
        StudRows : int
        Color : ConsoleColor
    }
    
module Brick =
    
    let printConsole (brick : Brick) =
        
        let rowChar =
            match brick.StudRows with
            | 1 -> "."
            | 2 -> ":"
            | _ -> raise <| ArgumentException "Not Supported row count"
        
        let pattern = String.replicate brick.StudColumns rowChar
        printf $"{brick.Color.ToString().Substring(0,1)}"
        Console.BackgroundColor <- brick.Color
        Console.ForegroundColor <- ConsoleColor.Black
        printf $"[{pattern}]"
        printf " "
